using System;
using System.Collections.Generic;

namespace APIMDEmployee.Data
{
    public partial class RunningNumber
    {
        public string KeyUsed { get; set; } = null!;
        public long ValueLastUsed { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
