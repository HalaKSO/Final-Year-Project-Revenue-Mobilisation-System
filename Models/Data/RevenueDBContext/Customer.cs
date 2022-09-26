using System;
using System.Collections.Generic;

#nullable disable

namespace RevenueApp.Models.Data.RevenueDBContext
{
    public partial class Customer
    {
        public Customer()
        {
            BusinessBills = new HashSet<BusinessBill>();
            BusinessDailyPayments = new HashSet<BusinessDailyPayment>();
            Businesses = new HashSet<Business>();
            HouseBills = new HashSet<HouseBill>();
            HouseDailyPayments = new HashSet<HouseDailyPayment>();
            Houses = new HashSet<House>();
        }

        public int CustomerId { get; set; }
        public int ImageId { get; set; }
        public int RelationId { get; set; }
        public string CustomerFname { get; set; }
        public string CustomerLname { get; set; }
        public DateTime CustomerDoB { get; set; }
        public string CustomerTinNumber { get; set; }
        public string GhanaCardNumber { get; set; }
        public string CustomerResidentialAddress { get; set; }
        public string CustomerDigitalAddress { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerNationality { get; set; }
        public string CustomerSsn { get; set; }
        public string CustomerNextOfKinContact { get; set; }
        public string CustomerContact { get; set; }
        public string CustomerNextOfKin { get; set; }
        public int GenderId { get; set; }
        public int TitleId { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual Image Image { get; set; }
        public virtual Relation Relation { get; set; }
        public virtual Title Title { get; set; }
        public virtual ICollection<BusinessBill> BusinessBills { get; set; }
        public virtual ICollection<BusinessDailyPayment> BusinessDailyPayments { get; set; }
        public virtual ICollection<Business> Businesses { get; set; }
        public virtual ICollection<HouseBill> HouseBills { get; set; }
        public virtual ICollection<HouseDailyPayment> HouseDailyPayments { get; set; }
        public virtual ICollection<House> Houses { get; set; }
    }
}
