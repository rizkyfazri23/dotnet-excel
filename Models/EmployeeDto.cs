using System;
using System.Collections.Generic;

namespace APIMDEmployee.Models
{
    public partial class EmployeeDto
    {
        public string EmployeeNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string EmployeeName { get; set; } = null!;
        public string Grade { get; set; } = null!;
        public int DepartmentRowId { get; set; }
        public int BankRowId { get; set; }
        public string BankName { get; set; } = null!;
        public string AccountName { get; set; } = null!;
        public string AccountNo { get; set; } = null!;
        public bool IsActive { get; set; }
        public string IsDelete { get; set; } = null!;
    }
}
