using System;
using System.Collections.Generic;

#nullable disable

namespace RevenueApp.Models.Data.RevenueDBContext
{
    public partial class BusinessCategory
    {
        public BusinessCategory()
        {
            BusinessRates = new HashSet<BusinessRate>();
            Businesses = new HashSet<Business>();
        }

        public int BusCatId { get; set; }
        public string BusCatName { get; set; }

        public virtual ICollection<BusinessRate> BusinessRates { get; set; }
        public virtual ICollection<Business> Businesses { get; set; }
    }
}
