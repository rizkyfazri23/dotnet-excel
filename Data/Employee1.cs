using System;
using System.Collections.Generic;

namespace APIMDEmployee.Data
{
    public partial class Employee1
    {
        public int RowId { get; set; }
        public string EmployeeNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string EmployeeName { get; set; } = null!;
        public string Grade { get; set; } = null!;
        public int DepartmentRowId { get; set; }
        public int? CostCenterRowId { get; set; }
        public DateTime? LastUpdate { get; set; }
        public int BankRowId { get; set; }
        public string AccountName { get; set; } = null!;
        public string AccountNo { get; set; } = null!;
        public string? Status { get; set; }
        public int? K2wfprocessInstanceId { get; set; }
        public int? MdemployeeRowId { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual Bank BankRow { get; set; } = null!;
        public virtual CostCenter? CostCenterRow { get; set; }
        public virtual Department DepartmentRow { get; set; } = null!;
        public virtual Employee? MdemployeeRow { get; set; }
    }
}
