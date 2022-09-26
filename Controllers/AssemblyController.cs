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
    public class AssemblyController : Controller
    {
        private AssemblyService _AssemblyService;
        public AssemblyController(AssemblyService assemblyService)
        {
            _AssemblyService = assemblyService;

        }
        // GET: AssemblyController
        public ActionResult Index()
        {
            var model = _AssemblyService.GetAssembly();
            return View(model);
        }

        // GET: AssemblyController/Details/5
        public ActionResult Details(int id)
        {
            var model = _AssemblyService.GetAssemblyDetails(id);
            return View(model);
        }

        // GET: AssemblyController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AssemblyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AssemblyViewModel model)
        {
            try
            {

                bool result = _AssemblyService.AddAssembly(model);
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

        // GET: AssemblyController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _AssemblyService.GetAssemblyDetails(id);
            return View(model);
        }

        // POST: AssemblyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AssemblyViewModel model)
        {
            try
            {
                bool result = _AssemblyService.UpdateAssembly(model);
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

        // GET: AssemblyController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _AssemblyService.GetAssemblyDetails(id);
            return View(model);
        }

        // POST: AssemblyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                bool result = _AssemblyService.DeleteAssembly(id);
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
