using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RevenueApp.Models.Data.ViewModel
{
    public class BusinessRateViewModel
    {
        [Key]
        public int BusRateId { get; set; }
        [NotMapped]
        public int BusCatId { get; set; }
        [NotMapped]
        public SelectList BusCatList { get; set; }
        public string BusRate { get; set; }
    }
}
