using System;
using System.Collections.Generic;

namespace APIMDEmployee.Data
{
    public partial class DebitBank1
    {
        public int RowId { get; set; }
        public int BankRowId { get; set; }
        public string BankAccountCode { get; set; } = null!;
        public string BankAccountNo { get; set; } = null!;
        public string BankAccountName { get; set; } = null!;
        public string BankCode { get; set; } = null!;
        public int CurrencyRowId { get; set; }
        public string? Status { get; set; }
        public int? K2wfprocessInstanceId { get; set; }
        public int? MddebitBankRowId { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual Bank BankRow { get; set; } = null!;
        public virtual Currency CurrencyRow { get; set; } = null!;
        public virtual DebitBank? MddebitBankRow { get; set; }
    }
}
