using System;
using System.Collections.Generic;

#nullable disable

namespace RevenueApp.Models.Data.RevenueDBContext
{
    public partial class HouseDailyPayment
    {
        public int HsePaymentId { get; set; }
        public int HseId { get; set; }
        public string HseAmount { get; set; }
        public DateTime HsePaymentDate { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual House Hse { get; set; }
    }
}
