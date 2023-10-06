using System;
using System.Collections.Generic;

namespace APIMDEmployee.Data
{
    public partial class Whttype
    {
        public Whttype()
        {
            Whttype1s = new HashSet<Whttype1>();
        }

        public int RowId { get; set; }
        public int WhtarticleRowId { get; set; }
        public string SubType { get; set; } = null!;
        public decimal RateWithTaxId { get; set; }
        public decimal RateWithOutTaxId { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? StatusWf { get; set; }

        public virtual Whtarticle WhtarticleRow { get; set; } = null!;
        public virtual ICollection<Whttype1> Whttype1s { get; set; }
    }
}
