using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using RevenueApp.Models.Data.ViewModel;
using System;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace RevenueApp.Models.Data.Services
{
    public class AccountService
    {
        private UserManager<ApplicationUser> _UserManager;
        private RoleManager<IdentityRole> _RoleManager;
        private SignInManager<ApplicationUser> _SignInManager;
        private GenderService _GenderService;
        private RevenueDBContext.RevenueDBContext _Context;
        public AccountService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager, GenderService genderService, RevenueDBContext.RevenueDBContext context)
        {
            _UserManager = userManager;
            _RoleManager = roleManager;
            _SignInManager = signInManager;
            _GenderService = genderService;
            _Context = context;
        }
        public AccountViewModel CreateAccounts()
        {
            AccountViewModel model = new AccountViewModel()
            {
                GenderList = new SelectList(_GenderService.GetGender(), "GenderId", "GenderType")
            };

            return model;
        }


        public async Task<IdentityResult> AccountRegistration(AccountViewModel model, int id)
        {
            byte[] imageByte;
            if (model.ImageFile != null)
            {
                using (var stream = new MemoryStream())
                {
                    model.ImageFile.CopyTo(stream);
                    imageByte = stream.ToArray();
                }
            }
            else
            {
                imageByte = File.ReadAllBytes(GetDefaultImagePath());
            }

            //Get username from email address
            MailAddress address = new MailAddress(model.EmailAddress);
            var userName = address.User;

            var newUser = new ApplicationUser
            {
                LastName = model.LastName,
                MiddleName = model.MiddleName,
                Firstname = model.Firstname,
                FullName = $"{model.Firstname} {model.MiddleName} {model.LastName}",
                BirthDate = model.BirthDate,
                GenderId = model.GenderId,
                Hometown = model.Hometown,
                Residence = model.Residence,
                Address = model.Address,
                PhoneNumber = model.ContactNumber,
                Email = model.EmailAddress,
                UserName = userName,
                ProfilePic = imageByte,
                RegistrationDate = Convert.ToDateTime(DateTime.Now.ToShortDateString())

            };

            var result = await _UserManager.CreateAsync(newUser, model.Password);

            if (result.Succeeded)
            {

                if (id == 1)
                {

                    await _UserManager.AddToRoleAsync(newUser, "Officer");
                }

                else
                {

                    await _UserManager.AddToRoleAsync(newUser, "Administrator");
                }

            }

            return result;

        }


        public async Task<SignInResult> LoginAsync(LoginViewModel model)
        {
            var userName = model.EmailAdress;
            MailAddress mailAddress = new MailAddress(model.EmailAdress);

            userName = mailAddress.User;


            var result = await _SignInManager.PasswordSignInAsync(userName, model.Password, model.RememberMe, lockoutOnFailure: false);

            return result;

        }


        public async Task LogOutAsync()
        {
            await _SignInManager.SignOutAsync();


        }


        private string GetDefaultImagePath()
        {
            var PhotofilePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\lib\images\UserImage.jpg");

            return PhotofilePath;
        }

        public AccountViewModel LoadAccount(ApplicationUser user)
        {
            AccountViewModel model = new()
            {
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                Firstname = user.Firstname,
                FullName = $"{user.Firstname} {user.MiddleName} {user.LastName}",
                BirthDate = user.BirthDate,
                GenderId = user.GenderId,
                Hometown = user.Hometown,
                Residence = user.Residence,
                Address = user.Address,
                ContactNumber = user.PhoneNumber,
                ProfilePic = user.ProfilePic,
                GenderList = new SelectList(_GenderService.GetGender(), "GenderId", "GenderType")
            };

            return model;
        }
        public async Task<bool> UpdateAccountAsync(AccountViewModel model, ApplicationUser user)
        {
            byte[] imageByte;

            if (model.ImageFile != null)
            {
                using (var stream = new MemoryStream())
                {
                    model.ImageFile.CopyTo(stream);
                    imageByte = stream.ToArray();
                }
            }
            else
            {
                imageByte = user.ProfilePic;
            }



            var users = _Context.Users.Where(x => x.Id == user.Id).FirstOrDefault();

            users.LastName = model.LastName;
            users.MiddleName = model.MiddleName;
            users.Firstname = model.Firstname;
            users.FullName = $"{model.Firstname} {model.MiddleName} {model.LastName}";
            users.BirthDate = model.BirthDate;
            users.GenderId = model.GenderId;
            users.Hometown = model.Hometown;
            users.Residence = model.Residence;
            users.Address = model.Address;
            users.PhoneNumber = model.ContactNumber;
            users.ProfilePic = imageByte;
                


         
            _Context.Users.Update(users);
            _Context.SaveChanges();


            return true;

        }


    }
}
