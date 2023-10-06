using System;
using System.Collections.Generic;

namespace APIMDEmployee.Data
{
    public partial class WorkflowRole
    {
        public WorkflowRole()
        {
            CostCenter1Level1Wfroles = new HashSet<CostCenter1>();
            CostCenter1Level2Wfroles = new HashSet<CostCenter1>();
            CostCenter1Level3Wfroles = new HashSet<CostCenter1>();
            CostCenter1Level4Wfroles = new HashSet<CostCenter1>();
            CostCenter1Level5Wfroles = new HashSet<CostCenter1>();
            CostCenterLevel1Wfroles = new HashSet<CostCenter>();
            CostCenterLevel2Wfroles = new HashSet<CostCenter>();
            CostCenterLevel3Wfroles = new HashSet<CostCenter>();
            CostCenterLevel4Wfroles = new HashSet<CostCenter>();
            CostCenterLevel5Wfroles = new HashSet<CostCenter>();
            WorkflowRole1s = new HashSet<WorkflowRole1>();
        }

        public int RowId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? StatusWf { get; set; }

        public virtual ICollection<CostCenter1> CostCenter1Level1Wfroles { get; set; }
        public virtual ICollection<CostCenter1> CostCenter1Level2Wfroles { get; set; }
        public virtual ICollection<CostCenter1> CostCenter1Level3Wfroles { get; set; }
        public virtual ICollection<CostCenter1> CostCenter1Level4Wfroles { get; set; }
        public virtual ICollection<CostCenter1> CostCenter1Level5Wfroles { get; set; }
        public virtual ICollection<CostCenter> CostCenterLevel1Wfroles { get; set; }
        public virtual ICollection<CostCenter> CostCenterLevel2Wfroles { get; set; }
        public virtual ICollection<CostCenter> CostCenterLevel3Wfroles { get; set; }
        public virtual ICollection<CostCenter> CostCenterLevel4Wfroles { get; set; }
        public virtual ICollection<CostCenter> CostCenterLevel5Wfroles { get; set; }
        public virtual ICollection<WorkflowRole1> WorkflowRole1s { get; set; }
    }
}
