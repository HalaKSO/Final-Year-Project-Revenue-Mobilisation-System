using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RevenueApp.Models.Data.ViewModel
{
    public class HouseDailyPaymentViewModel
    {
        [Key]
        public int HsePaymentId { get; set; }
        public int HseId { get; set; }
        [NotMapped]
        public SelectList HseList { get; set; }
        [NotMapped]
        public string HouseName { get; set; }

        public string HseAmount { get; set; }
        public DateTime HsePaymentDate { get; set; }
        public int CustomerId { get; set; }
        [NotMapped]
        public SelectList CustomerList { get; set; }
        [NotMapped]
        public string customerName { get; set; }
    }
}
