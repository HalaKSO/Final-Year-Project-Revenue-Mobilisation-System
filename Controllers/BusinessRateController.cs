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
    public class BusinessRateController : Controller
    {
        private readonly BusinessRateService _BusinessRateService;
        private readonly RevenueDBContext _Context;
        public BusinessRateController(BusinessRateService businessRateService, RevenueDBContext context)
        {
            _BusinessRateService = businessRateService;
            _Context = context;
        }
        // GET: BusinessRateController
        public ActionResult Index()
        {
            var model = _BusinessRateService.GetBRate();
            return View(model);
        }

        // GET: BusinessRateController/Details/5
        public ActionResult Details(int id)
        {
            var model = _BusinessRateService.GetBRateDetails(id);
            return View(model);
        }

        // GET: BusinessRateController/Create
        public ActionResult Create()
        {
            var model = _BusinessRateService.CreateBRate();
            return View(model);
        }

        // POST: BusinessRateController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BusinessRateViewModel model)
        {
            try
            {
                bool result = _BusinessRateService.AddBRate(model);
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

        // GET: BusinessRateController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _BusinessRateService.GetBRateDetails(id);
            return View(model);
        }

        // POST: BusinessRateController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BusinessRateViewModel model)
        {
            try
            {

                bool result = _BusinessRateService.UpdateBRate(model);
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

        // GET: BusinessRateController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _BusinessRateService.GetBRateDetails(id);
            return View(model);
        }

        // POST: BusinessRateController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                bool result = _BusinessRateService.DeleteBRate(id);
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
