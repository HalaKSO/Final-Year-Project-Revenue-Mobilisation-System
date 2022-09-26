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
    public class HouseRateController : Controller
    {
        private readonly HouseRateService _HouseRateService;
        private readonly RevenueDBContext _Context;
        public HouseRateController(HouseRateService houseRateService, RevenueDBContext context)
        {
            _HouseRateService = houseRateService;
            _Context = context;
        }
        // GET: HouseRateController
        public ActionResult Index()
        {
            var model = _HouseRateService.GetHRate();
            return View(model);
        }

        // GET: HouseRateController/Details/5
        public ActionResult Details(int id)
        {
            var model = _HouseRateService.GetHRateDetails(id);
            return View(model);
        }

        // GET: HouseRateController/Create
        public ActionResult Create()
        {
            var model = _HouseRateService.CreateHRate();
            return View(model);
        }

        // POST: HouseRateController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HouseRateViewModel model)
        {
            try
            {
                bool result = _HouseRateService.AddHRate(model);
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

        // GET: HouseRateController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _HouseRateService.GetHRateDetails(id);
            return View(model);
        }

        // POST: HouseRateController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HouseRateViewModel model)
        {
            try
            {
                bool result = _HouseRateService.UpdateHRate(model);
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

        // GET: HouseRateController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _HouseRateService.GetHRateDetails(id);
            return View(model);
        }

        // POST: HouseRateController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                bool result = _HouseRateService.DeleteHRate(id);
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
    }
}
