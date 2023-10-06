using System;
using System.Collections.Generic;

namespace APIMDEmployee.Data
{
    public partial class CategoryExpense
    {
        public CategoryExpense()
        {
            CategoryExpense1s = new HashSet<CategoryExpense1>();
            TransactionExpense1s = new HashSet<TransactionExpense1>();
            TransactionExpenses = new HashSet<TransactionExpense>();
        }

        public int RowId { get; set; }
        public string TransactionType { get; set; } = null!;
        public string ExpenseType { get; set; } = null!;
        public string CategoryExpense1 { get; set; } = null!;
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? StatusWf { get; set; }

        public virtual ICollection<CategoryExpense1> CategoryExpense1s { get; set; }
        public virtual ICollection<TransactionExpense1> TransactionExpense1s { get; set; }
        public virtual ICollection<TransactionExpense> TransactionExpenses { get; set; }
    }
}
