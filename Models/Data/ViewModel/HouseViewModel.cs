using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RevenueApp.Models.Data.ViewModel
{
    public class HouseViewModel
    {
        [Key]
        public int HseId { get; set; }
        public string HseName { get; set; }
        public int CustomerId { get; set; }
        [NotMapped]
        public SelectList CustomerList { get; set; }
        [NotMapped]
        public string CustomerName { get; set; }
        [NotMapped]
        public string HouseCategoryName { get; set; }
        public string HseNumber { get; set; }
        public string HseLocation { get; set; }
        public string HseBlockNumber { get; set; }
        public string GhanaCardNo { get; set; }
        public int HseCatId { get; set; }
        [NotMapped]
        public SelectList HseCatList { get; set; }
        public string HseDigitalAddress { get; set; }
        public string HseTelNumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime HseRegDate { get; set; }
    }
}
