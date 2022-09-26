using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RevenueApp.Models;
using RevenueApp.Models.Data;
using RevenueApp.Models.Data.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RevenueApp.Controllers
{
    public class HomeController : Controller 
    {
       

        private UserManager<ApplicationUser> _UserManager;
        private RoleManager<IdentityRole> _roleManager;
        private SignInManager<ApplicationUser> _SignInManager;
        private GenderService _GenderService;
        private AccountService _AccountService;
        public HomeController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager, GenderService genderService, AccountService accountService)
        {
            _UserManager = userManager;
            _roleManager = roleManager;
            _SignInManager = signInManager;
            _GenderService = genderService;
            _AccountService = accountService;
        }
        public new async Task<ActionResult> Index()
        {
            await GenerateRolesAsync();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task GenerateRolesAsync()
        {

            var AdminRoleExist = await _roleManager.FindByNameAsync("Administrator");
            var OfficerRoleExist = await _roleManager.FindByNameAsync("Officer");


            if (AdminRoleExist == null)
            {
                var CreateAdmin = _roleManager.CreateAsync(new IdentityRole("Administrator")).Result;
            }
            if (OfficerRoleExist == null)
            {
                var CreateOfficer = _roleManager.CreateAsync(new IdentityRole("Officer")).Result;
            }


        }
    }
}
