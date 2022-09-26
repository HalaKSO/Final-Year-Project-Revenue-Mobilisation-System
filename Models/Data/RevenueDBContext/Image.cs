using System;
using System.Collections.Generic;

#nullable disable

namespace RevenueApp.Models.Data.RevenueDBContext
{
    public partial class Image
    {
        public Image()
        {
            Customers = new HashSet<Customer>();
            OfficerAdmins = new HashSet<OfficerAdmin>();
        }

        public int ImageId { get; set; }
        public byte[] Photo { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<OfficerAdmin> OfficerAdmins { get; set; }
    }
}
