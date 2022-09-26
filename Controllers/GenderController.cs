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
    public class GenderController : Controller
    {
        private GenderService _GenderService;
        public GenderController(GenderService genderService)
        {
            _GenderService = genderService;

        }
        // GET: GenderController
        public ActionResult Index()
        {
            var model = _GenderService.GetGender();
            return View(model);
        }

        // GET: GenderController/Details/5
        public ActionResult Details(int id)
        {
            var model = _GenderService.GetGenderDetails(id);
            return View(model);
        }

        // GET: GenderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GenderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GenderViewModel model)
        {
            try
            {

                bool result = _GenderService.AddGender(model);
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

        // GET: GenderController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _GenderService.GetGenderDetails(id);
            return View(model);
        }

        // POST: GenderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GenderViewModel model)
        {
            try
            {
                bool result = _GenderService.UpdateGender(model);
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

        // GET:GenderController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _GenderService.GetGenderDetails(id);
            return View(model);
        }

        // POST:GenderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                bool result = _GenderService.DeleteGender(id);
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
