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
    public class TitleController : Controller
    {
        private TitleService _TitleService;
        public TitleController(TitleService titleService)
        {
            _TitleService = titleService;

        }
        // GET: TitleController
        public ActionResult Index()
        {
            var model = _TitleService.GetTitle();
            return View(model);
        }

        // GET: TitleController/Details/5
        public ActionResult Details(int id)
        {
            var model = _TitleService.GetTitleDetails(id);
            return View(model);
        }

        // GET: TitleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AssemblyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TitleViewModel model)
        {
            try
            {

                bool result = _TitleService.AddTitle(model);
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

        // GET: TitleController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _TitleService.GetTitleDetails(id);
            return View(model);
        }

        // POST: TitleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TitleViewModel model)
        {
            try
            {
                bool result = _TitleService.UpdateTitle(model);
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

        // GET: TitleController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _TitleService.GetTitleDetails(id);
            return View(model);
        }

        // POST:TitleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                bool result = _TitleService.DeleteTitle(id);
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
