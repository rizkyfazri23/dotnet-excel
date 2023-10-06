using System;
using System.Collections.Generic;

namespace APIMDEmployee.Data
{
    public partial class Whtarticle
    {
        public Whtarticle()
        {
            Whtarticle1s = new HashSet<Whtarticle1>();
            Whttype1s = new HashSet<Whttype1>();
            Whttypes = new HashSet<Whttype>();
        }

        public int RowId { get; set; }
        public string Type { get; set; } = null!;
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? StatusWf { get; set; }

        public virtual ICollection<Whtarticle1> Whtarticle1s { get; set; }
        public virtual ICollection<Whttype1> Whttype1s { get; set; }
        public virtual ICollection<Whttype> Whttypes { get; set; }
    }
}
