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
    public class OfficeRankController : Controller
    {
        private OfficeRankService _OfficeRankService;
        public OfficeRankController(OfficeRankService officeRankService)
        {
            _OfficeRankService = officeRankService;

        }
        // GET: OfficeRankController
        public ActionResult Index()
        {
            var model = _OfficeRankService.GetRanks();
            return View(model);
        }

        // GET: OfficeRankController/Details/5
        public ActionResult Details(int id)
        {
            var model = _OfficeRankService.GetRankDetails(id);
            return View(model);
        }

        // GET: OfficeRankController/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: OfficeRankController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OfficeRankViewModel model)
        {
            try
            {

                bool result = _OfficeRankService.AddRanks(model);
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

        // GET: OfficeRankController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _OfficeRankService.GetRankDetails(id);
            return View(model);
        }

        // POST: OfficeRankController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OfficeRankViewModel model)
        {
            try
            {
                bool result = _OfficeRankService.UpdateRanks(model);
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

        // GET:OfficRankController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _OfficeRankService.GetRankDetails(id);
            return View(model);
        }

        // POST:OfficeRankController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                bool result = _OfficeRankService.DeleteRank(id);
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
