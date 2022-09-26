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
    public class AccountViewModel
    {
        [RegularExpression(@"^[a-zA-Z-\s]*$", ErrorMessage = "Invalid data type")]
        [Required]
        public string Firstname { get; set; }
        [RegularExpression(@"^[a-zA-Z-\s]*$", ErrorMessage = "Invalid data type")]
        [Required]
        public string MiddleName { get; set; }
        [RegularExpression(@"^[a-zA-Z-\s]*$", ErrorMessage = "Invalid data type")]
        [Required]
        public string LastName { get; set; }
        [NotMapped]
        public string FullName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public int GenderId { get; set; }
        [NotMapped]
        public SelectList GenderList { get; set; }
        [NotMapped]
        public string GenderName { get; set; }
        public string Hometown { get; set; }
        public string Address { get; set; }
        public string Residence { get; set; }
        public byte[] ProfilePic { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [NotMapped]
        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        [Key]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[0-9+]*$", ErrorMessage = "Invalid data type")]
        [Required]
        public string ContactNumber { get; set; }

    }
}
