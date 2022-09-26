using Microsoft.AspNetCore.Identity;
using RevenueApp.Models.Data.RevenueDBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevenueApp.Models.Data
{
    public class ApplicationUser:IdentityUser
    {
        public string Firstname { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        public string Hometown { get; set; }
        public string Address { get; set; }
        public string Residence { get; set; }
        public byte[] ProfilePic { get; set; }
       
        public DateTime RegistrationDate { get; set; } 




    }
}
