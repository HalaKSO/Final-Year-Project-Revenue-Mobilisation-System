using System;
using System.Collections.Generic;

#nullable disable

namespace RevenueApp.Models.Data.RevenueDBContext
{
    public partial class Gender
    {
        public Gender()
        {
            Customers = new HashSet<Customer>();
            OfficerAdmins = new HashSet<OfficerAdmin>();
        }

        public int GenderId { get; set; }
        public string GenderType { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<OfficerAdmin> OfficerAdmins { get; set; }
    }
}
