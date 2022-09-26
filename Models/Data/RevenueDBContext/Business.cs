using System;
using System.Collections.Generic;

#nullable disable

namespace RevenueApp.Models.Data.RevenueDBContext
{
    public partial class Business
    {
        public Business()
        {
            BusinessBills = new HashSet<BusinessBill>();
            BusinessDailyPayments = new HashSet<BusinessDailyPayment>();
        }

        public int BusId { get; set; }
        public int CustomerId { get; set; }
        public int BusCatId { get; set; }
        public string BusName { get; set; }
        public string BusLocation { get; set; }
        public string BusBlockNumber { get; set; }
        public string BusDigitalAddress { get; set; }
        public string BusTelNumber { get; set; }
        public DateTime BusRegDate { get; set; }

        public virtual BusinessCategory BusCat { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<BusinessBill> BusinessBills { get; set; }
        public virtual ICollection<BusinessDailyPayment> BusinessDailyPayments { get; set; }
    }
}
