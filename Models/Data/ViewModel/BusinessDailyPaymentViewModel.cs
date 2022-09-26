using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RevenueApp.Models.Data.ViewModel
{
    public class BusinessDailyPaymentViewModel
    {
        [Key]
        public int BusPaymentId { get; set; }
        [NotMapped]
        public int BusId { get; set; }
        [NotMapped]
        public SelectList BusinessList { get; set; }
        
        public string BusAmount { get; set; }
        [DataType(DataType.Date)]
        public DateTime BusinessDailyPaymentDate { get; set; }
        [NotMapped]
        public SelectList CustomerList { get; set; }
        
        public int CustomerId { get; set; }
        [NotMapped]
        public string CustomerName { get; set; }
        [NotMapped]
        public int BusBillNumber { get; set; }
        [NotMapped]
        public string BusinessName { get; set; }

    }
}
