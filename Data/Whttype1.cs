using System;
using System.Collections.Generic;

namespace APIMDEmployee.Data
{
    public partial class Whttype1
    {
        public int RowId { get; set; }
        public int WhtarticleRowId { get; set; }
        public string SubType { get; set; } = null!;
        public decimal RateWithTaxId { get; set; }
        public decimal RateWithOutTaxId { get; set; }
        public string? Status { get; set; }
        public int? K2wfprocessInstanceId { get; set; }
        public int? MdwhttypeRowId { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual Whttype? MdwhttypeRow { get; set; }
        public virtual Whtarticle WhtarticleRow { get; set; } = null!;
    }
}
