using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RevenueApp.Models.Data.ViewModel
{
    public class HouseRateViewModel
    {
        [Key]
        public int HseRateId { get; set; }
        public int HseCatId { get; set; }
        [NotMapped]
        public SelectList HseCatList { get; set; }

        public string HseRate { get; set; }
    }
}
