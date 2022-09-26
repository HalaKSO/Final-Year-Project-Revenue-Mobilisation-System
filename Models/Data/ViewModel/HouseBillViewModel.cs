using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RevenueApp.Models.Data.ViewModel
{
    public class HouseBillViewModel
    {
        [Key]
        public int HseBillNumber { get; set; }
        public DateTime HseBillDate { get; set; }
        public int HseId { get; set; }
        [NotMapped]
        public SelectList HseList { get; set; }
        public string YearBill { get; set; }
        public string HseCurrentBill { get; set; }
        public string HsePrevBill { get; set; }
        public string HsePrevPayment { get; set; }
        public string HseArrears { get; set; }
        public string HseTotalAmtDue { get; set; }
        public int CustomerId { get; set; }
        [NotMapped]
        public SelectList CustomerList { get; set; }
        public string CustomerName { get; set; }
        public int HseRateId { get; set; }
        [NotMapped]
        public SelectList HseRateList { get; set; }
    }
} 
