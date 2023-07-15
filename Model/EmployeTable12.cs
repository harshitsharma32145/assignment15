using System;
using System.Collections.Generic;

namespace Assignment8July.Model
{
    public partial class EmployeTable12
    {
        public int EmpId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? GenderId { get; set; }
        public DateTime? Dob { get; set; }
        public string? Phonenum { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string? Zipcode { get; set; }
        public string? Address { get; set; }

        public virtual CityTable12? City { get; set; }
        public virtual CountryTable12? Country { get; set; }
        public virtual GenderTable12? Gender { get; set; }
        public virtual StateTable12? State { get; set; }
    }
}
