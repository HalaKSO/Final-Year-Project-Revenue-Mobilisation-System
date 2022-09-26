using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RevenueApp.Models.Data.RevenueDBContext;
using RevenueApp.Models.Data.Services;
using RevenueApp.Models.Data.ViewModel;
using System;

namespace RevenueApp.Controllers
{
    public class BusinessBillController : Controller
    {
        private readonly BusinessBillService _BusinessBillService;
        private readonly RevenueDBContext _Context;
        public BusinessBillController(BusinessBillService businessBillService, RevenueDBContext context)
        {
            _BusinessBillService = businessBillService;
            _Context = context;
        }
        // GET: BusinessBillController
        public ActionResult Index()
        {
            return View();
        }
          public ActionResult BusinessBillList()
        {
            var model = _BusinessBillService.GetBBill();
            return Json(new { data = model });
        }

        // GET: BusinessBillController/Details/5
        public ActionResult Details(int id)
        {
            var model = _BusinessBillService.GetBBillDetails(id);
            return View(model);
        }

        // GET: BusinessBillController/Create
        public ActionResult Create()
        {
            var model = _BusinessBillService.CreateBBill();
            return View(model);
        }

        // POST: BusinessBillController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BusinessBillViewModel model)
        {
            try
            {
                bool result = _BusinessBillService.AddBBill(model);
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

        // GET: BusinessBillController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _BusinessBillService.GetBBillDetails(id);
            return View(model);
        }

        // POST: BusinessBillController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BusinessBillViewModel model)
        {
            try
            {
                bool result = _BusinessBillService.UpdateBBill(model);
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

        

        // POST: BusinessBillController/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                bool result = _BusinessBillService.DeleteBBill(id);
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

        //Get all the bills of individual customers
        public ActionResult GetAllCustomerYearBills(int id)
        {
            var model = _BusinessBillService.GetAllCustomerYearBills(id);
            return View(model);
        }


    }
}
