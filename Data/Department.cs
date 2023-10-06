using System;
using System.Collections.Generic;

namespace APIMDEmployee.Data
{
    public partial class Department
    {
        public Department()
        {
            CostCenter1s = new HashSet<CostCenter1>();
            CostCenters = new HashSet<CostCenter>();
            Department1s = new HashSet<Department1>();
            Employee1s = new HashSet<Employee1>();
            Employees = new HashSet<Employee>();
        }

        public int RowId { get; set; }
        public string DepartmentCode { get; set; } = null!;
        public string DepartmentName { get; set; } = null!;
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? StatusWf { get; set; }

        public virtual ICollection<CostCenter1> CostCenter1s { get; set; }
        public virtual ICollection<CostCenter> CostCenters { get; set; }
        public virtual ICollection<Department1> Department1s { get; set; }
        public virtual ICollection<Employee1> Employee1s { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
