using APIMDEmployee.Data;
using APIMDEmployee.Models;

using NPOI.SS.UserModel;
using NPOI.SS.Util;

using System.Text.RegularExpressions;

namespace APIMDEmployee.Utils
{
    public class ReadExcelDataManager
    {
        private readonly ePaymentContext _paymentContext;

        public ReadExcelDataManager(ePaymentContext paymentContext)
        {
            _paymentContext = paymentContext;
        }

        public List<UploadResponseDto> GetDataFromExcel(ISheet sheet)
        {
            List<UploadResponseDto> listResult = new List<UploadResponseDto>();
            List<EmployeeDto> listDataEmployee = new List<EmployeeDto>();

            Regex emailVal = new Regex("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$");
            string[] IsDelete = new string[] { "YES", "NO" };

            int rowDataStart = 1;
            try
            {
                for (int rowIndex = rowDataStart; rowIndex <= sheet.LastRowNum; rowIndex++)
                {
                    string[] Column = new string[] {
                        new CellAddress(rowIndex, 0).FormatAsString(),
                        new CellAddress(rowIndex, 1).FormatAsString(),
                        new CellAddress(rowIndex, 2).FormatAsString(),
                        new CellAddress(rowIndex, 3).FormatAsString(),
                        new CellAddress(rowIndex, 4).FormatAsString(),
                        new CellAddress(rowIndex, 5).FormatAsString(),
                        new CellAddress(rowIndex, 6).FormatAsString(),
                        new CellAddress(rowIndex, 7).FormatAsString(),
                        new CellAddress(rowIndex, 8).FormatAsString()
                    };

                    IRow currentRow = sheet.GetRow(rowIndex);
                    if (currentRow != null)
                    {
                        UploadResponseDto responseDto = new UploadResponseDto();
                        EmployeeDto newData = new EmployeeDto();

                        if (currentRow.GetCell(0).IsCellHasValue())
                        {
                            newData.Email = currentRow.GetStringCellValueWithDefault(0);
                            newData.UserName = currentRow.GetStringCellValueWithDefault(1);
                            newData.EmployeeNumber = currentRow.GetStringCellValueWithDefault(2);
                            newData.Grade = currentRow.GetStringCellValueWithDefault(3);
                            newData.DepartmentRowId = currentRow.GetNumericCellValueWithDefault(4).ToInt();
                            newData.BankName = currentRow.GetStringCellValueWithDefault(5);
                            newData.AccountName = currentRow.GetStringCellValueWithDefault(6);
                            newData.AccountNo = currentRow.GetStringCellValueWithDefault(7);
                            newData.IsDelete = currentRow.GetStringCellValueWithDefault(8);

                            #region validation

                            CheckMandatoryColumn(sheet, rowIndex, listResult);

                            if (!emailVal.IsMatch(newData.Email))
                            {
                                responseDto = new UploadResponseDto();
                                responseDto.Column = Column[0];
                                responseDto.Message = "Format email is not valid";
                                responseDto.DataValue = newData.Email;

                                listResult.Add(responseDto);
                            }

                            var chekBank = _paymentContext.Banks.FirstOrDefault(x => x.BankCode == newData.BankName);

                            if (chekBank == null)
                            {
                                responseDto = new UploadResponseDto();
                                responseDto.Column = Column[5];
                                responseDto.Message = "Data is not found from master";
                                responseDto.DataValue = newData.BankName;

                                listResult.Add(responseDto);
                            }
                            else
                            {
                                newData.BankRowId = chekBank.RowId;
                            }

                            if (!IsDelete.Contains(newData.IsDelete.ToUpper()))
                            {
                                responseDto = new UploadResponseDto();
                                responseDto.Column = Column[8];
                                responseDto.Message = "Data is not valid";
                                responseDto.DataValue = newData.IsDelete;

                                listResult.Add(responseDto);
                            }
                            else
                            {
                                var chekEmployee = _paymentContext.Employees.FirstOrDefault(x => x.EmployeeNumber == newData.EmployeeNumber);

                                if (chekEmployee == null && newData.IsDelete.ToUpper() == IsDelete[0])
                                {
                                    responseDto = new UploadResponseDto();
                                    responseDto.Column = Column[8];
                                    responseDto.Message = "Delete failed, Data not found";
                                    responseDto.DataValue = newData.IsDelete;

                                    listResult.Add(responseDto);
                                }
                            }

                            if (listDataEmployee.Count > 0)
                            {
                                if (listDataEmployee.Exists(x => x.Email == newData.Email))
                                {
                                    responseDto = new UploadResponseDto();
                                    responseDto.Column = Column[0];
                                    responseDto.Message = "Email must be unique";
                                    responseDto.DataValue = newData.Email;

                                    listResult.Add(responseDto);
                                }
                                if (listDataEmployee.Exists(x => x.UserName == newData.UserName))
                                {
                                    responseDto = new UploadResponseDto();
                                    responseDto.Column = Column[1];
                                    responseDto.Message = "User Name must be unique";
                                    responseDto.DataValue = newData.UserName;

                                    listResult.Add(responseDto);
                                }
                                if (listDataEmployee.Exists(x => x.EmployeeNumber == newData.EmployeeNumber))
                                {
                                    responseDto = new UploadResponseDto();
                                    responseDto.Column = Column[2];
                                    responseDto.Message = "Employee Number must be unique";
                                    responseDto.DataValue = newData.EmployeeNumber;

                                    listResult.Add(responseDto);
                                }
                            }

                            #endregion validation

                            listDataEmployee.Add(newData);
                        }
                    }
                }

                if (listResult.Count > 0)
                {
                    return listResult;
                }
                else
                {
                    foreach (EmployeeDto employee in listDataEmployee)
                    {
                        if (employee != null)
                        {
                            var checkEmployee = _paymentContext.Employees
                                .FirstOrDefault(x => x.EmployeeNumber == employee.EmployeeNumber &&
                                employee.IsDelete.ToUpper() == IsDelete[1]);

                            if (checkEmployee == null) // INSERT EMPLOYEE
                            {
                                Employee newData = new Employee();

                                newData.Email = employee.Email;
                                newData.UserName = employee.UserName;
                                newData.EmployeeNumber = employee.EmployeeNumber;
                                newData.EmployeeName = string.Empty;
                                newData.Grade = employee.Grade;
                                newData.DepartmentRowId = employee.DepartmentRowId;
                                newData.BankRowId = employee.BankRowId;
                                newData.AccountName = employee.AccountName;
                                newData.AccountNo = employee.AccountNo;
                                newData.IsActive = employee.IsDelete.ToUpper() == IsDelete[1]; // NO
                                newData.CreatedBy = "System";
                                newData.CreatedOn = DateTime.Now;

                                _paymentContext.Employees.Add(newData);
                            }
                            else
                            {
                                checkEmployee.Email = employee.Email;
                                checkEmployee.UserName = employee.UserName;
                                checkEmployee.EmployeeNumber = employee.EmployeeNumber;
                                //checkEmployee.EmployeeName = string.Empty;
                                checkEmployee.Grade = employee.Grade;
                                checkEmployee.DepartmentRowId = employee.DepartmentRowId;
                                checkEmployee.BankRowId = employee.BankRowId;
                                checkEmployee.AccountName = employee.AccountName;
                                checkEmployee.AccountNo = employee.AccountNo;
                                checkEmployee.IsActive = employee.IsDelete.ToUpper() == IsDelete[1]; // NO
                                checkEmployee.ModifiedBy = "System";
                                checkEmployee.ModifiedOn = DateTime.Now;
                            }
                        }
                    }

                    _paymentContext.SaveChanges();

                    return listResult;
                }
            }
            catch
            {
                throw;
            }
        }

        private void CheckMandatoryColumn(ISheet sheet, int rowIndex, List<UploadResponseDto> listResult)
        {
            List<int> listColumn = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

            IRow columnRow = sheet.GetRow(0);

            IRow currentRow = sheet.GetRow(rowIndex);

            if (currentRow != null)
            {
                foreach (var index in listColumn)
                {
                    if (!currentRow.GetCell(index).IsCellHasValue())
                    {
                        UploadResponseDto responseDto = new UploadResponseDto();
                        responseDto.Column = new CellAddress(rowIndex, index).FormatAsString();
                        responseDto.Message = string.Format("{0} is required", columnRow.GetStringCellValueWithDefault(index));
                        responseDto.DataValue = string.Empty;

                        listResult.Add(responseDto);
                    }
                }
            }
        }
    }
}
