using System;
using System.Collections.Generic;

#nullable disable

namespace RevenueApp.Models.Data.RevenueDBContext
{
    public partial class House
    {
        public House()
        {
            HouseBills = new HashSet<HouseBill>();
            HouseDailyPayments = new HashSet<HouseDailyPayment>();
        }

        public int HseId { get; set; }
        public int CustomerId { get; set; }
        public string HseNumber { get; set; }
        public string HseLocation { get; set; }
        public string HseBlockNumber { get; set; }
        public int HseCatId { get; set; }
        public string HseDigitalAddress { get; set; }
        public string HseTelNumber { get; set; }
        public DateTime HseRegDate { get; set; }
        public string HseName { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual HouseCategory HseCat { get; set; }
        public virtual ICollection<HouseBill> HouseBills { get; set; }
        public virtual ICollection<HouseDailyPayment> HouseDailyPayments { get; set; }
    }
}
