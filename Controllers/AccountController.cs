using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RevenueApp.Models.Data;
using RevenueApp.Models.Data.RevenueDBContext;
using RevenueApp.Models.Data.Services;
using RevenueApp.Models.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace RevenueApp.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _UserManager;
        private RoleManager<IdentityRole> _roleManager;
        private SignInManager<ApplicationUser> _SignInManager;
        private GenderService _GenderService;
        private AccountService _AccountService;
        private RevenueDBContext _db;
        public AccountController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager, GenderService genderService, AccountService accountService, RevenueDBContext db)
        {
            _UserManager = userManager;
            _roleManager = roleManager;
            _SignInManager = signInManager;
            _GenderService = genderService;
            _AccountService = accountService;
            _db = db;
        }
        // GET: AccountController
        public ActionResult Index()
        {
            return View();
        }

        

        // GET: AccountController/Create
        public ActionResult OfficerAccountRegistration()
        {
            
            var model = _AccountService.CreateAccounts();
            return View(model);
        }

        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> OfficerAccountRegistration(AccountViewModel model)
        {
            try
            {
                var result =  await _AccountService.AccountRegistration(model, 1);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                return View(); 
            }
            catch(Exception)
            {
                return View();
            }
        }
        
      // GET: AccountController/Create
        public ActionResult AdminAccountRegistration()
        {
            
            var model = _AccountService.CreateAccounts();
            return View(model);
        }

        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AdminAccountRegistration(AccountViewModel model)
        {
            try
            {
                var result =  await _AccountService.AccountRegistration(model, 2);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                return View(); 
            }
            catch(Exception)
            {
                return View();
            }
        }

      // GET: AccountController/Create
        public ActionResult Login()
        {
            
            return View();
        }

        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model) 
        {
            try
            {
                var result = await _AccountService.LoginAsync(model);
                if (result.Succeeded)
                {
                    MailAddress address = new(model.EmailAdress);
                    var userName = address.User;
                    var GetUserId = await _UserManager.FindByNameAsync(userName);

                    var UserHasRole = WhatRoleIsUser(GetUserId.Id);

                    if (UserHasRole == "Officer")
                    {
                        //go to student page
                        return RedirectToAction("OfficerDashboard", "Dashboard");
                    }
                    else
                    {
                        //go to admin page
                        return RedirectToAction("AdminDashboard", "Dashboard");
                    }


                }

                throw new Exception();
            }
            catch(Exception)
            {
                return View();
            }
        }


        
        public async Task<ActionResult> LogOut()
        {
            await _AccountService.LogOutAsync();
            return RedirectToAction("Index","Home");

        }




      // GET: AccountController/Create
        public async Task<ActionResult> GetUserDetails()
        {
            var user = await _UserManager.GetUserAsync(User);
            if(user == null)
            {
                return NotFound("Unable to load your account information");
            }
            var model = _AccountService.LoadAccount(user);
            return View(model);
        }

        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> GetUserDetails(AccountViewModel model)  
        {
            try
            {
                var user = await _UserManager.GetUserAsync(User);
                bool result = await _AccountService.UpdateAccountAsync(model,user);
                if (result)
                {
                    ViewData["Notification"] = "Your information successfully updated!";
                    return RedirectToAction("GetUserDetails", "Account");
                }
               
                throw new Exception();
            }
            catch(Exception)
            {
                return View();
            }
        }

        public string WhatRoleIsUser(string userId)
        {
            var GetUserRoleId = _db.UserRoles.Where(x => x.UserId == userId).FirstOrDefault();
            var GetUserRole = _db.Roles.Where(x => x.Id == GetUserRoleId.RoleId).FirstOrDefault();


            return GetUserRole.Name;

        }

    }
}
