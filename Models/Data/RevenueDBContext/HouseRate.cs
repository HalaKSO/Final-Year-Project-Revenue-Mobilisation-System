using System;
using System.Collections.Generic;

#nullable disable

namespace RevenueApp.Models.Data.RevenueDBContext
{
    public partial class HouseRate
    {
        public HouseRate()
        {
            HouseBills = new HashSet<HouseBill>();
        }

        public int HseRateId { get; set; }
        public string HseRate { get; set; }
        public int HseCatId { get; set; }

        public virtual HouseCategory HseCat { get; set; }
        public virtual ICollection<HouseBill> HouseBills { get; set; }
    }
}
