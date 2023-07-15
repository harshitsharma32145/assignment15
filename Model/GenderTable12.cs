using System;
using System.Collections.Generic;

namespace Assignment8July.Model
{
    public partial class GenderTable12
    {
        public GenderTable12()
        {
            EmployeTable12s = new HashSet<EmployeTable12>();
        }

        public int GenderId { get; set; }
        public string? Gender { get; set; }

        public virtual ICollection<EmployeTable12> EmployeTable12s { get; set; }
    }
}
