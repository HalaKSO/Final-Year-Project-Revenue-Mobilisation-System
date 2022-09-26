using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RevenueApp.Models.Data.ViewModel
{
    public class BusinessBillViewModel
    {
        [Key]
        public int BusBillNumber { get; set; }
        public string YearBill { get; set; }
        [NotMapped]
        public DateTime BusBillDate { get; set; }
        [NotMapped]
        public int BusId { get; set; }
        [NotMapped]
        public SelectList BusinessList { get; set; }
        public string BusCurrentBill { get; set; }
        public string BusPrevBill { get; set; }
        public string BusPrevPayment { get; set; }
        public string BusArrears { get; set; }
 
        public string BusTotalAmtDue { get; set; }
        public int BusRateId { get; set; }
        [NotMapped]
        public SelectList BusRateList { get; internal set; }
        [NotMapped]
        public SelectList CustomerList { get; internal set; }
        [NotMapped]
        public int CustomerId { get; set; } 
        [NotMapped]
        public string CustomerName { get; set; } 


    }
}
