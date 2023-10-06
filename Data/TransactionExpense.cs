using System;
using System.Collections.Generic;

namespace APIMDEmployee.Data
{
    public partial class TransactionExpense
    {
        public TransactionExpense()
        {
            TransactionExpense1s = new HashSet<TransactionExpense1>();
        }

        public int RowId { get; set; }
        public int CategoryExpenseRowId { get; set; }
        public string TransactionExpense1 { get; set; } = null!;
        public int CoarowId { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? StatusWf { get; set; }

        public virtual CategoryExpense CategoryExpenseRow { get; set; } = null!;
        public virtual Coa Coarow { get; set; } = null!;
        public virtual ICollection<TransactionExpense1> TransactionExpense1s { get; set; }
    }
}
