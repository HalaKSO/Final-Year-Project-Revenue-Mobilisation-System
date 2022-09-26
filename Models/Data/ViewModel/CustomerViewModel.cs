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
    public class CustomerViewModel
    {
        [Key]
        public int CustomerId { get; set; }
        public int ImageId { get; set; }
        [NotMapped]
    
        public int RelationId { get; set; }
        [NotMapped]
        public SelectList RelationList { get; set; }
        [NotMapped]
        [RegularExpression(@"^[a-zA-Z-\s]*$", ErrorMessage = "Invalid data type")]
        [Required]
        public string RelationType { get; internal set; }
        [NotMapped]
        [RegularExpression(@"^[a-zA-Z-\s]*$", ErrorMessage = "Invalid data type")]
        [Required]
        public string CustomerFname { get; set; }
        [RegularExpression(@"^[a-zA-Z-\s]*$", ErrorMessage = "Invalid data type")]
        [Required]
        public string CustomerLname { get; set; }
             
        [DataType(DataType.Date)]
        public DateTime CustomerDoB { get; set; }
        public string CustomerTinNumber { get; set; }
        public string GhanaCardNumber { get; set; }
        public string CustomerResidentialAddress { get; set; }
        public string CustomerDigitalAddress { get; set; }
        [DataType(DataType.EmailAddress)]
        public string CustomerEmail { get; set; }
        [RegularExpression(@"^[a-zA-Z-\s]*$", ErrorMessage = "Invalid data type")]
        [Required]
        public string CustomerNationality { get; set; }
        public string CustomerSsn { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[0-9+]*$", ErrorMessage = "Invalid data type")]
        public string CustomerNextOfKinContact { get; set; }
        [Required]
        [RegularExpression(@"^[0-9+]*$", ErrorMessage = "Invalid data type")]
        [DataType(DataType.PhoneNumber)]
        public string CustomerContact { get; set; }
        [RegularExpression(@"^[a-zA-Z-\s]*$", ErrorMessage = "Invalid data type")]
        [Required]
        public string CustomerNextOfKin { get; set; }
        public int GenderId { get; set; }
        [NotMapped]
        public SelectList GenderList { get; set; }
        [NotMapped]
        public int TitleId { get; set; }
        [NotMapped]
        public SelectList TitleList { get; set; }
        [NotMapped]
        [RegularExpression(@"^[a-zA-Z-\s]*$", ErrorMessage = "Invalid data type")]
        public string FullName { get; internal set; }
        [NotMapped]
       
        public string TitleName { get; internal set; }
        [NotMapped]
        public string GenderType { get; internal set; }
        [NotMapped]
        public IFormFile Image { get; set; }
        [NotMapped]
        public byte[] Photos { get; internal set; }
        [NotMapped]
        public string base64stringpic { get; set; }
    }
}
