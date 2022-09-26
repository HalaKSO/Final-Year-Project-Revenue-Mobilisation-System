using System;
using System.Collections.Generic;

#nullable disable

namespace RevenueApp.Models.Data.RevenueDBContext
{
    public partial class HouseCategory
    {
        public HouseCategory()
        {
            HouseRates = new HashSet<HouseRate>();
            Houses = new HashSet<House>();
        }

        public int HseCatId { get; set; }
        public string HseCatName { get; set; }

        public virtual ICollection<HouseRate> HouseRates { get; set; }
        public virtual ICollection<House> Houses { get; set; }
    }
}
