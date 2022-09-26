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
    public class HouseDailyPaymentController : Controller
    {
        private readonly HouseDailyPaymentService _HouseDailyPaymentService;
        private readonly RevenueDBContext _Context;
        private UserManager<ApplicationUser> _UserManager;
        public HouseDailyPaymentController(HouseDailyPaymentService houseDailyPaymentService, RevenueDBContext context, UserManager<ApplicationUser> userManager)
        {
            _HouseDailyPaymentService = houseDailyPaymentService;
            _Context = context;
            _UserManager = userManager;
        }
        // GET: HouseDailyPaymentController
        public ActionResult Index()
        {
            
            return View();
        } 
        public ActionResult HouseDPList()
        {
            var model = _HouseDailyPaymentService.GetHDP();

            return Json(new { data = model });
        }

        // GET: HouseDailyPaymentController/Details/5
        public ActionResult Details(int id)
        {
            var model = _HouseDailyPaymentService.GetHDPDetails(id);
            return View(model);
        }

        // GET: HouseDailyPaymentController/Create
        public ActionResult Payment(int id)
        {
            ViewData["Id"] = id;
            return View();
        }

        // POST: HouseDailyPaymentController/Create 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> PaymentAsync(HouseDailyPaymentViewModel model)
        {
            //using hseId for simply passing data
            int id = model.HseId;
            try
            {
                var user = await _UserManager.GetUserAsync(User);
                bool result = await _HouseDailyPaymentService.AddHDPAsync(model, id,user);
                if (result == true)
                {
                    ViewData["Notification"] = "Thank you for the payment.A payment receipt is sent to your email";
                    return RedirectToAction(nameof(Index));
                }
                throw new Exception();
            }
            catch
            {
                return View();
            }
        }

        // GET: HouseDailyPaymentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HouseDailyPaymentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HouseDailyPaymentViewModel model)
        {
            try
            {

                bool result = _HouseDailyPaymentService.UpdateHDP(model);
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
       

        

        // POST: HouseDailyPaymentController/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                bool result = _HouseDailyPaymentService.DeleteHseDP(id);
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
