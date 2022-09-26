using System;
using System.Collections.Generic;

#nullable disable

namespace RevenueApp.Models.Data.RevenueDBContext
{
    public partial class Assembly
    {
        public Assembly()
        {
            OfficerAdmins = new HashSet<OfficerAdmin>();
        }

        public int AssemblyId { get; set; }
        public string AssemblyName { get; set; }

        public virtual ICollection<OfficerAdmin> OfficerAdmins { get; set; }
    }
}
