using System;
using System.Collections.Generic;

namespace APIMDEmployee.Data
{
    public partial class Currency
    {
        public Currency()
        {
            Currency1s = new HashSet<Currency1>();
            DebitBank1s = new HashSet<DebitBank1>();
            DebitBanks = new HashSet<DebitBank>();
            Rpvvendors = new HashSet<Rpvvendor>();
        }

        public int RowId { get; set; }
        public string CurrencyCode { get; set; } = null!;
        public string CurrencyName { get; set; } = null!;
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? StatusWf { get; set; }

        public virtual ICollection<Currency1> Currency1s { get; set; }
        public virtual ICollection<DebitBank1> DebitBank1s { get; set; }
        public virtual ICollection<DebitBank> DebitBanks { get; set; }
        public virtual ICollection<Rpvvendor> Rpvvendors { get; set; }
    }
}
