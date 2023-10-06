using System;
using System.Collections.Generic;

namespace APIMDEmployee.Data
{
    public partial class Pvnumber
    {
        public long RowId { get; set; }
        public long RpvrowId { get; set; }
        public string Pvnumber1 { get; set; } = null!;
        public string PaymentType { get; set; } = null!;
        public DateTime TransferDate { get; set; }
        public string Status { get; set; } = null!;
        public string TransactionId { get; set; } = null!;
        public string DocumentId { get; set; } = null!;
        public string PartyId { get; set; } = null!;
        public string TransactionReferenceNo { get; set; } = null!;
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual Rpvvendor Rpvrow { get; set; } = null!;
    }
}
