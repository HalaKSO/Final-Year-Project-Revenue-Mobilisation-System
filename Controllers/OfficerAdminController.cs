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
using System.Threading.Tasks;

namespace RevenueApp.Controllers
{
    public class OfficerAdminController : Controller  
    {
        private readonly OfficerAdminService _OfficerAdminService;
        private readonly RevenueDBContext _Context;
        private UserManager<ApplicationUser> _UserManager;
        public OfficerAdminController(OfficerAdminService officerAdminService, RevenueDBContext context, UserManager<ApplicationUser> userManager)
        {
            _OfficerAdminService = officerAdminService;
            _Context = context;
            _UserManager = userManager;
        }
        // GET: Controller
        public ActionResult Index()
        {
            
            return View();
        }
        [HttpGet]
        public ActionResult StaffList()
        {
            var model = _OfficerAdminService.GetOfficerAdmin();

            return Json(new { data = model });
        }
         public ActionResult OfficerDetails()
        {
            var userId = _UserManager.GetUserId(User);
            var user = _Context.Users.Where(x => x.Id == userId).FirstOrDefault();
             
            //check if officers are more than 1
            OfficerAdmin officer = _Context.OfficerAdmins.Where(x => x.OfficerEmail == user.Email).FirstOrDefault();
            var model = _OfficerAdminService.GetOfficerAdminById(officer.StaffId);
            return View(model);
        }
        

        // GET: OfficerAdminController/Details/5
        public ActionResult StaffDetails(int id)
        {
            var model = _OfficerAdminService.GetOfficerAdminDetails(id);
            return View(model);
        }

        // GET: OfficerAdminController/Create
        public ActionResult AddStaff()
        {
            var model = _OfficerAdminService.CreateOfficeAdmin();
            return View(model);
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddStaff(OfficerAdminViewModel model)
        {
            try
            {

                bool result = _OfficerAdminService.AddStaff(model);
                if (result == true)
                {
                    return RedirectToAction(nameof(Index));
                }
                throw new Exception();
            }
            catch
            {
                return View();
            }
        }

        // GET: OfficerAdminController/Edit/5
        public ActionResult UpdateStaff(int id)
        {
           
            var model = _OfficerAdminService.GetOfficerAdminDetails(id);
            return View(model);
        }

        // POST: OfficerAdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateStaff(OfficerAdminViewModel model)
        {
            try
            {
                bool result = _OfficerAdminService.UpdateStaff(model);
                if (result == true)
                {
                    return RedirectToAction(nameof(OfficerDetails));
                }
                throw new Exception();
            }
            catch
            {
                return View();
            }
        }

     

        // POST:OfficerAdminController/Delete/5
        [HttpDelete]
        
        public ActionResult RemoveStaff(int id)
        {
            try
            {
                bool result = _OfficerAdminService.DeleteOfficeAdmin(id);
                if (result == true)
                {
                    return Json(new { success = true, message = "Data successfully deleted!" });
                }
                return RedirectToAction(nameof(Index));
                throw new Exception();
            }
            catch
            {
                return View();
            }
        }
    }
}
