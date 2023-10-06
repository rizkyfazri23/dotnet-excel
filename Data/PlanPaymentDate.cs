using System;
using System.Collections.Generic;

namespace APIMDEmployee.Data
{
    public partial class PlanPaymentDate
    {
        public int RowId { get; set; }
        public string Name { get; set; } = null!;
        public int Year { get; set; }
        public int Month { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
