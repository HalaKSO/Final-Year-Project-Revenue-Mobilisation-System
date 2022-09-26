using System;
using System.Collections.Generic;

#nullable disable

namespace RevenueApp.Models.Data.RevenueDBContext
{
    public partial class Title
    {
        public Title()
        {
            Customers = new HashSet<Customer>();
            OfficerAdmins = new HashSet<OfficerAdmin>();
        }

        public int TitleId { get; set; }
        public string TitleName { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<OfficerAdmin> OfficerAdmins { get; set; }
    }
}
