using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RevenueApp.Models.Data.ViewModel
{
    public class AssemblyViewModel
    {
        [Key]
        public int AssemblyId { get; set; }
        public string AssemblyName { get; set; }
    }
}
