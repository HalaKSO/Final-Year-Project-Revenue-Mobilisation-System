using System;
using System.Collections.Generic;

#nullable disable

namespace RevenueApp.Models.Data.RevenueDBContext
{
    public partial class BusinessBill
    {
        public BusinessBill()
        {
            BusinessDailyPayments = new HashSet<BusinessDailyPayment>();
        }

        public int BusBillNumber { get; set; }
        public DateTime BusBillDate { get; set; }
        public int BusId { get; set; }
        public string YearBill { get; set; }
        public string BusCurrentBill { get; set; }
        public string BusPrevPayment { get; set; }
        public string BusArrears { get; set; }
        public string BusTotalAmtDue { get; set; }
        public int BusRateId { get; set; }
        public int CustomerId { get; set; }

        public virtual Business Bus { get; set; }
        public virtual BusinessRate BusRate { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<BusinessDailyPayment> BusinessDailyPayments { get; set; }
    }
}
