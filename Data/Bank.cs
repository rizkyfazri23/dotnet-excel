using System;
using System.Collections.Generic;

namespace APIMDEmployee.Data
{
    public partial class Bank
    {
        public Bank()
        {
            Bank1s = new HashSet<Bank1>();
            DebitBank1s = new HashSet<DebitBank1>();
            DebitBanks = new HashSet<DebitBank>();
            Employee1s = new HashSet<Employee1>();
            Employees = new HashSet<Employee>();
        }

        public int RowId { get; set; }
        public string BankName { get; set; } = null!;
        public string BankCode { get; set; } = null!;
        public string SwiftCode { get; set; } = null!;
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? StatusWf { get; set; }

        public virtual ICollection<Bank1> Bank1s { get; set; }
        public virtual ICollection<DebitBank1> DebitBank1s { get; set; }
        public virtual ICollection<DebitBank> DebitBanks { get; set; }
        public virtual ICollection<Employee1> Employee1s { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
