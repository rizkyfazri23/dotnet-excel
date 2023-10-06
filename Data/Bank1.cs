using System;
using System.Collections.Generic;

namespace APIMDEmployee.Data
{
    public partial class Bank1
    {
        public int RowId { get; set; }
        public string BankName { get; set; } = null!;
        public string BankCode { get; set; } = null!;
        public string SwiftCode { get; set; } = null!;
        public string? Status { get; set; }
        public int? K2wfprocessInstanceId { get; set; }
        public int? MdbankRowId { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual Bank? MdbankRow { get; set; }
    }
}
