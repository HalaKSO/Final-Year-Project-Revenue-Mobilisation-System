using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RevenueApp.Models.Data.RevenueDBContext;
using RevenueApp.Models.Data.Services;
using RevenueApp.Models.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevenueApp.Controllers
{
    public class HouseBillController : Controller
    {
        private readonly HouseBillService _HouseBillService;
        private readonly RevenueDBContext _Context;
        public HouseBillController(HouseBillService houseBillService, RevenueDBContext context)
        {
            _HouseBillService = houseBillService;
            _Context = context;
        }
        // GET: HouseBillController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult HouseBillList()
        {
            var model = _HouseBillService.GetHBill();

            return Json(new { data = model });
        }

        // GET: HouseBillController/Details/5
        public ActionResult Details(int id)
        {
            var model = _HouseBillService.GetHBillDetails(id);
            return View(model);
        }

        // GET: HouseBillController/Create
        public ActionResult Create()
        {
            var model = _HouseBillService.CreateHBill();
            return View(model);
        }

        // POST: HouseBillController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HouseBillViewModel model)
        {
            try
            {
                bool result = _HouseBillService.AddHBill(model);
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

        // GET: HouseBillController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _HouseBillService.GetHouseBillById(id);
            return View(model);
        }

        // POST: HouseBillController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HouseBillViewModel model)
        {
            try
            {
                bool result = _HouseBillService.UpdateHBill(model);
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


        // POST: HouseBillController/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                bool result = _HouseBillService.DeleteHBill(id);
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
