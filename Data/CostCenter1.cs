using System;
using System.Collections.Generic;

namespace APIMDEmployee.Data
{
    public partial class CostCenter1
    {
        public int RowId { get; set; }
        public int DepartmentRowId { get; set; }
        public string CostCenterCode { get; set; } = null!;
        public string CostCenterName { get; set; } = null!;
        public int? Level1WfroleId { get; set; }
        public int? Level2WfroleId { get; set; }
        public int? Level3WfroleId { get; set; }
        public int? Level4WfroleId { get; set; }
        public int? Level5WfroleId { get; set; }
        public bool IsCostCenterProject { get; set; }
        public string ExpenseType { get; set; } = null!;
        public string? Status { get; set; }
        public int? K2wfprocessInstanceId { get; set; }
        public int? MdcostCenterRowId { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual Department DepartmentRow { get; set; } = null!;
        public virtual WorkflowRole? Level1Wfrole { get; set; }
        public virtual WorkflowRole? Level2Wfrole { get; set; }
        public virtual WorkflowRole? Level3Wfrole { get; set; }
        public virtual WorkflowRole? Level4Wfrole { get; set; }
        public virtual WorkflowRole? Level5Wfrole { get; set; }
        public virtual CostCenter? MdcostCenterRow { get; set; }
    }
}
