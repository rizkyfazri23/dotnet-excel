using System;
using System.Collections.Generic;

namespace APIMDEmployee.Data
{
    public partial class Rpvvendor
    {
        public Rpvvendor()
        {
            Pvnumbers = new HashSet<Pvnumber>();
        }

        public long RowId { get; set; }
        public string RequestPvnumber { get; set; } = null!;
        public string RevisionNumber { get; set; } = null!;
        public DateTime RequestDate { get; set; }
        public DateTime? RequestPaymentDate { get; set; }
        public string PaymentType { get; set; } = null!;
        public int SupplierRowId { get; set; }
        public string SupplierName { get; set; } = null!;
        public int MakerEmployeeRowId { get; set; }
        public string MakerName { get; set; } = null!;
        public string MakerDepartmentName { get; set; } = null!;
        public int RequestorEmployeeRowId { get; set; }
        public string RequestorName { get; set; } = null!;
        public int CurrencyRowId { get; set; }
        public string CurrencyCode { get; set; } = null!;
        public decimal GrossAmount { get; set; }
        public decimal? Vatamount { get; set; }
        public decimal? Whtamount { get; set; }
        public decimal NetAmount { get; set; }
        public bool IsPkp { get; set; }
        public bool IsAccrual { get; set; }
        public bool IsJournal { get; set; }
        public string? InvoiceNumber { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public int? InvoiceAttachmentId { get; set; }
        public DateTime? InvoiceDueDate { get; set; }
        public int? BeneficiaryRowId { get; set; }
        public string? BankDescription { get; set; }
        public int? PlanPaymentDateRowId { get; set; }
        public int? DebitBankRowId { get; set; }
        public bool? IsSkb { get; set; }
        public int? SkbdocAttachmentRowId { get; set; }
        public bool? IsCod { get; set; }
        public int? CoddocAttachmentRowId { get; set; }
        public bool? IsRelatedLicense { get; set; }
        public int? DocTreatyAttachmentRowId { get; set; }
        public decimal? Whtrate { get; set; }
        public string? Remarks { get; set; }
        public int? OtherAttachmentRowId { get; set; }
        public string? Status { get; set; }
        public int? K2wfprocessInstanceId { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual Currency CurrencyRow { get; set; } = null!;
        public virtual Employee MakerEmployeeRow { get; set; } = null!;
        public virtual Employee RequestorEmployeeRow { get; set; } = null!;
        public virtual ICollection<Pvnumber> Pvnumbers { get; set; }
    }
}
