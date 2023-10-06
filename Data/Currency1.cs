using System;
using System.Collections.Generic;

namespace APIMDEmployee.Data
{
    public partial class Currency1
    {
        public int RowId { get; set; }
        public string CurrencyCode { get; set; } = null!;
        public string CurrencyName { get; set; } = null!;
        public string? Status { get; set; }
        public int? K2wfprocessInstanceId { get; set; }
        public int? MdcurrencyRowId { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual Currency? MdcurrencyRow { get; set; }
    }
}
