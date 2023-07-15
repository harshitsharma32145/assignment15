using System;
using System.Collections.Generic;

namespace Assignment8July.Model
{
    public partial class CityTable12
    {
        public CityTable12()
        {
            EmployeTable12s = new HashSet<EmployeTable12>();
        }

        public int CityId { get; set; }
        public string? City { get; set; }
        public int? StateId { get; set; }

        public virtual StateTable12? State { get; set; }
        public virtual ICollection<EmployeTable12> EmployeTable12s { get; set; }
    }
}
