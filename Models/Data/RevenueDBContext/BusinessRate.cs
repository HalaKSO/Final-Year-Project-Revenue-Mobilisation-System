using System;
using System.Collections.Generic;

#nullable disable

namespace RevenueApp.Models.Data.RevenueDBContext
{
    public partial class BusinessRate
    {
        public BusinessRate()
        {
            BusinessBills = new HashSet<BusinessBill>();
        }

        public int BusRateId { get; set; }
        public int BusCatId { get; set; }
        public string BusRate { get; set; }

        public virtual BusinessCategory BusCat { get; set; }
        public virtual ICollection<BusinessBill> BusinessBills { get; set; }
    }
}
