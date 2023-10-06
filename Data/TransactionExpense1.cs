using System;
using System.Collections.Generic;

namespace APIMDEmployee.Data
{
    public partial class TransactionExpense1
    {
        public int RowId { get; set; }
        public int CategoryExpenseRowId { get; set; }
        public string TransactionExpense { get; set; } = null!;
        public int CoarowId { get; set; }
        public string? Status { get; set; }
        public int? K2wfprocessInstanceId { get; set; }
        public int? MdtransactionExpenseRowId { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual CategoryExpense CategoryExpenseRow { get; set; } = null!;
        public virtual Coa Coarow { get; set; } = null!;
        public virtual TransactionExpense? MdtransactionExpenseRow { get; set; }
    }
}
