using System;
using System.Collections.Generic;

namespace APIMDEmployee.Data
{
    public partial class Coa
    {
        public Coa()
        {
            Coa1s = new HashSet<Coa1>();
            TransactionExpense1s = new HashSet<TransactionExpense1>();
            TransactionExpenses = new HashSet<TransactionExpense>();
        }

        public int RowId { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public bool? IsAttributable { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? StatusWf { get; set; }

        public virtual ICollection<Coa1> Coa1s { get; set; }
        public virtual ICollection<TransactionExpense1> TransactionExpense1s { get; set; }
        public virtual ICollection<TransactionExpense> TransactionExpenses { get; set; }
    }
}
