using System;
using System.Collections.Generic;

namespace APIMDEmployee.Data
{
    public partial class WorkflowRole1
    {
        public int RowId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Status { get; set; }
        public int? K2wfprocessInstanceId { get; set; }
        public int? MdwfroleRowId { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual WorkflowRole? MdwfroleRow { get; set; }
    }
}
