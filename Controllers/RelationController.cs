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
    public class RelationController : Controller 
    {
        private RelationService _RelationService;
        public RelationController(RelationService relationService)
        {
            _RelationService = relationService;

        }
        // GET: RelationController
        public ActionResult Index()
        {          
            return View();
        }

        [HttpGet]
        public ActionResult RelationList()
        {
            var model = _RelationService.GetRelation();
            return Json(new { data = model });
        }

        // GET: RelationController/Details/5
        public ActionResult Details(int id)
        {
            var model = _RelationService.GetRelationDetails(id);
            return View(model);
        }

        // GET: RelationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RelationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RelationViewModel model)
        {
            try
            {

                bool result = _RelationService.AddRelation(model);
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

        // GET: RelationController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _RelationService.GetRelationDetails(id);
            return View(model);
        }

        // POST: RelationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RelationViewModel model)
        {
            try
            {
                bool result = _RelationService.UpdateRelation(model);
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

        
        // POST:RelationController/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                bool result = _RelationService.DeleteRelation(id);
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
