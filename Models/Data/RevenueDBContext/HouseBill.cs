using System;
using System.Collections.Generic;

#nullable disable

namespace RevenueApp.Models.Data.RevenueDBContext
{
    public partial class HouseBill
    {
        public int HseBillNumber { get; set; }
        public DateTime HseBillDate { get; set; }
        public int HseId { get; set; }
        public string HseCurrentBill { get; set; }
        public string HsePrevPayment { get; set; }
        public string HseArrears { get; set; }
        public string HseTotalAmtDue { get; set; }
        public int CustomerId { get; set; }
        public int HseRateId { get; set; }
        public string YearBill { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual House Hse { get; set; }
        public virtual HouseRate HseRate { get; set; }
    }
}
