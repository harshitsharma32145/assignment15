using System;
using System.Collections.Generic;

namespace Assignment8July.Model
{
    public partial class CountryTable12
    {
        public CountryTable12()
        {
            EmployeTable12s = new HashSet<EmployeTable12>();
            StateTable12s = new HashSet<StateTable12>();
        }

        public int CountryId { get; set; }
        public string? CountryName { get; set; }

        public virtual ICollection<EmployeTable12> EmployeTable12s { get; set; }
        public virtual ICollection<StateTable12> StateTable12s { get; set; }
    }
}
