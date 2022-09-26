using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RevenueApp.Models.Data.Services;
using RevenueApp.Models.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevenueApp.Controllers
{
    public class BusinessCategoryController : Controller
    {
        private BusinessCategoryService _BusinessCategoryService;
        public BusinessCategoryController(BusinessCategoryService businessCategoryService)
        {
            _BusinessCategoryService = businessCategoryService;

        }
        // GET: BusinessCategoryController
        public ActionResult Index()
        {
            var model = _BusinessCategoryService.GetBusCat();
            return View(model);
        }

        // GET: BusinessCategoryController/Details/5
        public ActionResult Details(int id)
        {
            var model = _BusinessCategoryService.GetBusCatDetails(id);
            return View(model);
        }

        // GET: BusinessCategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BusinessCategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BusinessCategoryViewModel model)
        {
            try
            {

                bool result = _BusinessCategoryService.AddBusCat(model);
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

        // GET: BusinessCategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _BusinessCategoryService.GetBusCatDetails(id);
            return View(model);
        }

        // POST: BusinessCategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BusinessCategoryViewModel model)
        {
            try
            {
                bool result = _BusinessCategoryService.UpdateBusCat(model);
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

        // GET: BusinessCategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _BusinessCategoryService.GetBusCatDetails(id);
            return View(model);
        }

        // POST: BusinessCategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                bool result = _BusinessCategoryService.DeleteBusCat(id);
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
