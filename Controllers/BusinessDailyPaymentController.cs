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
    public class BusinessDailyPaymentController : Controller
    {
        private readonly BusinessDailyPaymentService _BusinessDailyPaymentService;
        private readonly RevenueDBContext _Context;
        private UserManager<ApplicationUser> _UserManager;
        public BusinessDailyPaymentController(BusinessDailyPaymentService businessDailyPaymentService, RevenueDBContext context, UserManager<ApplicationUser> userManager)
        {
            _BusinessDailyPaymentService = businessDailyPaymentService;
            _Context = context;
            _UserManager = userManager;
        }
        // GET: BusinessDailyPaymentController
        public ActionResult Index()
        {
            return View();
        } 
        public ActionResult BusinessDPList()
        {
            var model = _BusinessDailyPaymentService.GetBDP();
            return Json(new { data = model });
        }


        // GET: BusinessDailyPaymentController/Details/5
        public ActionResult Details(int id)
        {
            var model = _BusinessDailyPaymentService.GetBDPDetails(id);
            return View(model);
        }

        // GET: BusinessDailyPaymentController/Create
        public ActionResult Payment()
        {
            var model = _BusinessDailyPaymentService.CreateBDP();
            return View(model);
        }

        // POST: BusinessDailyPaymentController/Create 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> PaymentAsync(BusinessDailyPaymentViewModel model,int id)
        {
            try
            {
                var user = await _UserManager.GetUserAsync(User);
                bool result = await _BusinessDailyPaymentService.AddBDPAsync(model, id, user);
                if(result == true)
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

        // GET: BusinessDailyPaymentController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _BusinessDailyPaymentService.GetBDPDetails(id);
            return View(model);
        }

        // POST: BusinessDailyPaymentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BusinessDailyPaymentViewModel model)
        {
            try
            {
                bool result = _BusinessDailyPaymentService.UpdateBDP(model);
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

       

        // POST: BusinessDailyPaymentController/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                bool result = _BusinessDailyPaymentService.DeleteBDP(id);
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
