using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RevenueApp.Models.Data.ViewModel
{
    public class RelationViewModel
    {
        [Key]
        public int RelationId { get; set; }
        public string RelationType { get; set; }
    }
}
