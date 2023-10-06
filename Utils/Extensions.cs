using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace APIMDEmployee.Utils
{
    public static class Extensions
    {
        public static ISheet GetFirstSheet(this string filePath)
        {
            ISheet? result = null;
            if (Path.GetExtension(filePath).ToUpper().Equals(".XLSX"))
            {
                result = filePath.GetFirstSheet_2007();
            }

            if (result == null)
            {
                throw new Exception("Invalid Excel file");
            }
            return result;
        }

        public static ISheet GetFirstSheet_2007(this string filePath)
        {
            XSSFWorkbook? workbook2007 = null;
            using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                workbook2007 = new XSSFWorkbook(file);
            }

            return workbook2007.GetSheetAt(0);
        }

        public static string GetStringCellValueWithDefault(this IRow row, int colIndex)
        {
            ICell currentCell = row.GetCell(colIndex);

            string result = string.Empty;

            if (currentCell == null)
            {
                result = string.Empty;
            }
            else
            {
                CellType usedType = currentCell.CellType;
                if (usedType == CellType.Formula)
                {
                    usedType = currentCell.CachedFormulaResultType;
                }

                switch (usedType)
                {
                    case CellType.Blank:
                        break;
                    case CellType.Boolean:
                        result = currentCell.BooleanCellValue.ToString();
                        break;
                    case CellType.Error:
                        break;
                    case CellType.Formula:
                        break;
                    case CellType.Numeric:
                        result = currentCell.NumericCellValue.ToString();
                        break;
                    case CellType.String:
                        result = currentCell.StringCellValue;
                        break;
                    case CellType.Unknown:
                        break;
                    default:
                        break;
                }
            }
            return result;
        }

        public static double GetNumericCellValueWithDefault(this IRow row, int colIndex)
        {
            ICell currentCell = row.GetCell(colIndex);
            double result = 0;
            if (currentCell != null)
            {
                try
                {
                    result = currentCell.NumericCellValue;
                }
                catch
                {
                    try
                    {
                        if (string.IsNullOrEmpty(currentCell.StringCellValue))
                        {
                            result = 0;
                        }
                        else
                        {
                            result = double.Parse(currentCell.StringCellValue);
                        }
                    }
                    catch (FormatException fex)
                    {
                        throw new FormatException("Cannot convert '" + currentCell.StringCellValue + "' into number. (Row=" + row.RowNum.ToString() + ",Col=" + colIndex.ToString() + ")", fex);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message + " (Row=" + row.RowNum.ToString() + ",Col=" + colIndex.ToString() + ")", ex);
                    }
                }
            }
            return result;
        }

        public static DateTime? GetDateCellValueNumericWithDefault(this IRow row, int colIndex, string? param = null)
        {
            ICell currentCell = row.GetCell(colIndex);
            DateTime? result = null;
            if (currentCell != null)
            {
                try
                {
                    result = currentCell.DateCellValue;
                    if (result.Value.Year == 1)     // if DateCellValue == 1/1/0001
                    {
                        result = null;
                    }
                }
                catch
                {
                    var TypeString = CellType.String;
                    var DateValue = currentCell.CellType == TypeString ? currentCell.StringCellValue : currentCell.NumericCellValue.ToString();

                    if (DateValue == "" || DateValue == "0")
                    {
                        result = null;
                    }
                    else
                    {
                        try
                        {
                            var yyyy = string.Empty;
                            var mm = string.Empty;
                            var dd = string.Empty;

                            if (!Regex.IsMatch(DateValue, @"^[0-9/-]+$"))      // IF NOT NUMBER OR CHAR "/-"
                            {
                                throw new Exception("Incorrect date format number");
                            }

                            if (!string.IsNullOrEmpty(param))   // FROM AGENCY COMMISSION MID OR END MONTH GL RELATED (MM/DD/YYYY) => "cmoemGL"
                            {
                                if (DateValue.Length < 8)   // IF TIMEZONE NOT EN-ID (INDONESIA)
                                {
                                    var DateZone = DateUtil.GetJavaDate(currentCell.NumericCellValue);
                                    DateValue = DateZone.ToString("MM/dd/yyyy");
                                }

                                string[] arrDate = DateValue.Split("/");

                                yyyy = arrDate[2];
                                mm = arrDate[0];
                                dd = arrDate[1];
                            }
                            else
                            {
                                yyyy = DateValue.Substring(0, 4);
                                mm = DateValue.Substring(4, 2);
                                dd = DateValue.Substring(6, 2);
                            }

                            var formatDate = yyyy + "/" + mm + "/" + dd;
                            result = DateTime.Parse(formatDate);
                        }
                        catch (Exception ex)
                        {
                            throw new FormatException("Cannot convert '" + DateValue + "' into Datetime. (Row=" + row.RowNum.ToString() + ",Col=" + colIndex.ToString() + ")", ex);
                        }
                    }
                }
            }
            return result;
        }

        public static bool IsCellHasValue(this ICell cell)
        {
            bool result = false;
            if (cell != null)
            {
                if (cell.CellType != CellType.Blank)
                {
                    result = true;
                }
            }
            return result;
        }

        public static decimal ToDecimal(this double value)
        {
            return Convert.ToDecimal(value);
        }

        public static int ToInt(this double value)
        {
            return Convert.ToInt32(value);
        }
    }
}
