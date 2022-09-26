using System;
using System.Collections.Generic;

#nullable disable

namespace RevenueApp.Models.Data.RevenueDBContext
{
    public partial class OfficeRank
    {
        public OfficeRank()
        {
            OfficerAdmins = new HashSet<OfficerAdmin>();
        }

        public int RankId { get; set; }
        public string RankName { get; set; }

        public virtual ICollection<OfficerAdmin> OfficerAdmins { get; set; }
    }
}
