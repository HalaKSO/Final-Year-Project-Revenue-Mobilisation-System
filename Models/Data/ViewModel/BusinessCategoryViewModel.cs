using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RevenueApp.Models.Data.ViewModel
{
    public class BusinessCategoryViewModel
    {
        [Key]
        public int BusCatId { get; set; }
        public string BusCatName { get; set; }
    }
}
