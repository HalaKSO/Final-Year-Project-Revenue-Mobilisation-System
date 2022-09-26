using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RevenueApp.Models.Data.ViewModel
{
    public class BusinessViewModel
    {
        [Key]
        public int BusId { get; set; }
        public string BusName { get; set; }
        [NotMapped]
        public int CustomerId { get; set; }
        [NotMapped]
        public string CustomerName { get; set; }
        [NotMapped]
        public SelectList CustomerList { get; set; }
        [NotMapped]
        public int BusCatId { get; set; }
        [NotMapped]
        public string BusinessCategoryName { get; set; }
        [NotMapped]
        public SelectList BusCatList { get; set; }
        public string BusLocation { get; set; }
        public string BusBlockNumber { get; set; }
        public string BusDigitalAddress { get; set; }
        public string GhanaCardNo { get; set; }  
        public string BusTelNumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime BusRegDate { get; set; }

    }
}
