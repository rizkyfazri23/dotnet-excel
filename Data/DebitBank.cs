using System;
using System.Collections.Generic;

namespace APIMDEmployee.Data
{
    public partial class DebitBank
    {
        public DebitBank()
        {
            DebitBank1s = new HashSet<DebitBank1>();
        }

        public int RowId { get; set; }
        public int BankRowId { get; set; }
        public string BankAccountCode { get; set; } = null!;
        public string BankAccountNo { get; set; } = null!;
        public string BankAccountName { get; set; } = null!;
        public string BankCode { get; set; } = null!;
        public int CurrencyRowId { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? StatusWf { get; set; }

        public virtual Bank BankRow { get; set; } = null!;
        public virtual Currency CurrencyRow { get; set; } = null!;
        public virtual ICollection<DebitBank1> DebitBank1s { get; set; }
    }
}
