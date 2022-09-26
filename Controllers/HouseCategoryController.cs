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
    public class HouseCategoryController : Controller
    {
        private readonly HouseCategoryService _HouseCategoryService;
        private readonly RevenueDBContext _Context;
        public HouseCategoryController(HouseCategoryService houseCategoryService, RevenueDBContext context)
        {
            _HouseCategoryService = houseCategoryService;
            _Context = context;
        }
        // GET: HouseCategoryController
        public ActionResult Index()
        {
            var model = _HouseCategoryService.GetHseCat();
            return View(model);
        }

        // GET: HouseCategoryController/Details/5
        public ActionResult Details(int id)
        {
            var model = _HouseCategoryService.GetHseCatDetails(id);
            return View();
        }

        // GET: HouseCategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HouseCategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HouseCategoryViewModel model)
        {
            try
            {
                bool result = _HouseCategoryService.AddHseCat(model);
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

        // GET: HouseCategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _HouseCategoryService.GetHseCatDetails(id);
            return View(model);
        }

        // POST: HouseCategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HouseCategoryViewModel model)
        {
            try
            {
                bool result = _HouseCategoryService.UpdateHseCat(model);
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

        // GET: HouseCategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _HouseCategoryService.GetHseCatDetails(id);
            return View();
        }

        // POST: HouseCategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                bool result = _HouseCategoryService.DeleteHseCat(id);
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
