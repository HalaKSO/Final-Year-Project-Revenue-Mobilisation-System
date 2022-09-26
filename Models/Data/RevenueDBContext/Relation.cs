using System;
using System.Collections.Generic;

#nullable disable

namespace RevenueApp.Models.Data.RevenueDBContext
{
    public partial class Relation
    {
        public Relation()
        {
            Customers = new HashSet<Customer>();
            OfficerAdmins = new HashSet<OfficerAdmin>();
        }

        public int RelationId { get; set; }
        public string RelationType { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<OfficerAdmin> OfficerAdmins { get; set; }
    }
}
