using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RevenueApp.Models.Data.ViewModel
{
    public class HouseCategoryViewModel
    {
        [Key]
        public int HseCatId { get; set; }
        public string HseCatName { get; set; }
    }
}
