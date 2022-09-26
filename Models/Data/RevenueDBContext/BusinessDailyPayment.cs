using System;
using System.Collections.Generic;

#nullable disable

namespace RevenueApp.Models.Data.RevenueDBContext
{
    public partial class BusinessDailyPayment
    {
        public int BusPaymentId { get; set; }
        public int BusId { get; set; }
        public string BusAmount { get; set; }
        public DateTime BusPaymentDate { get; set; }
        public int CustomerId { get; set; }
        public int BusBillNumber { get; set; }

        public virtual Business Bus { get; set; }
        public virtual BusinessBill BusBillNumberNavigation { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
