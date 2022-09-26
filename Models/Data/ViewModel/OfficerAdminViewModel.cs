using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RevenueApp.Models.Data.ViewModel
{
    public class OfficerAdminViewModel
    {
        [Key]
        public int StaffId { get; set; }
        
        public int GenderId { get; set; }
        [NotMapped]
        public SelectList GenderList { get; set; }
        [NotMapped]
        public string OfficerEmail { get; set; }
        public int RankId { get; set; }
        [NotMapped]
        public SelectList RankList { get; set; }
        [NotMapped]
        [RegularExpression(@"^[a-zA-Z-\s]*$", ErrorMessage = "Invalid data type")]
        [Required]
        public string OfficerFname { get; set; }
        [RegularExpression(@"^[a-zA-Z-\s]*$", ErrorMessage = "Invalid data type")]
        [Required]
        public string OfficerLname { get; set; }
        [NotMapped]
        public string SFullName { get; set; }
        [DataType(DataType.Date)]
        public DateTime OfficerDoB { get; set; }
        public string OfficerResidentialAddress { get; set; }
        public string OfficerDigitalAddress { get; set; }
        [Required]
        [RegularExpression(@"^[0-9+]*$", ErrorMessage = "Invalid data type")]
        [DataType(DataType.PhoneNumber)]
        public string OfficerContact { get; set; }
        public int ImageId { get; set; }
        [NotMapped]
        public int RelationId { get; set; }
        [NotMapped]
        public SelectList RelationList { get; set; }

        public int TitleId { get; set; }
        [NotMapped]

        public int AssemblyId { get; set; }
        [NotMapped]

        public SelectList AssemblyList { get; set; }
        [NotMapped]
        public string OfficerNextOfKin { get; set; }
        [NotMapped]
        public SelectList TitleList { get; internal set; }
        [NotMapped]
        [RegularExpression(@"^[a-zA-Z-\s]*$", ErrorMessage = "Invalid data type")]
        [Required]
        public string TitleName { get; internal set; }
        [NotMapped]
        [RegularExpression(@"^[a-zA-Z-\s]*$", ErrorMessage = "Invalid data type")]
        [Required]
        public string AssemblyName { get; internal set; }
        [NotMapped]
        public string RelationType { get; internal set; }
        [NotMapped]
        public string GenderType { get; internal set; }
        [NotMapped]
        public IFormFile Image { get; set; }
        [NotMapped]
        public byte[] Photos { get; internal set; }
        [NotMapped]
        [RegularExpression(@"^[a-zA-Z-\s]*$", ErrorMessage = "Invalid data type")]
        [Required]
        public string RankName { get; internal set; }
        [Required]
        [RegularExpression(@"^[0-9+]*$", ErrorMessage = "Invalid data type")]
        public string OfficerNextOfKinContact { get; set; }
        [NotMapped]
        public string base64stringpic { get; set; }

    }
}
