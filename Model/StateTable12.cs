using System;
using System.Collections.Generic;

namespace Assignment8July.Model
{
    public partial class StateTable12
    {
        public StateTable12()
        {
            CityTable12s = new HashSet<CityTable12>();
            EmployeTable12s = new HashSet<EmployeTable12>();
        }

        public int StateId { get; set; }
        public string? State { get; set; }
        public int? CountryId { get; set; }

        public virtual CountryTable12? Country { get; set; }
        public virtual ICollection<CityTable12> CityTable12s { get; set; }
        public virtual ICollection<EmployeTable12> EmployeTable12s { get; set; }
    }
}
