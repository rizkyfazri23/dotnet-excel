using System;
using System.Collections.Generic;

namespace APIMDEmployee.Data
{
    public partial class Whtarticle1
    {
        public int RowId { get; set; }
        public string Type { get; set; } = null!;
        public string? Status { get; set; }
        public int? K2wfprocessInstanceId { get; set; }
        public int? MdwhtarticleRowId { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual Whtarticle? MdwhtarticleRow { get; set; }
    }
}
