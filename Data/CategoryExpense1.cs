using System;
using System.Collections.Generic;

namespace APIMDEmployee.Data
{
    public partial class CategoryExpense1
    {
        public int RowId { get; set; }
        public string TransactionType { get; set; } = null!;
        public string ExpenseType { get; set; } = null!;
        public string CategoryExpense { get; set; } = null!;
        public string? Status { get; set; }
        public int? K2wfprocessInstanceId { get; set; }
        public int? MdcategoryExpenseRowId { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual CategoryExpense? MdcategoryExpenseRow { get; set; }
    }
}
