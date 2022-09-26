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
    public class HouseController : Controller
    {
        private readonly HouseService _HouseService;
        private readonly RevenueDBContext _Context;
        public HouseController(HouseService houseService, RevenueDBContext context)
        {
            _HouseService = houseService;
            _Context = context;
        }
        // GET: HouseController
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult HouseList()
        {
            var model = _HouseService.GetHouse();

            return Json(new { data = model });
        }

        public ActionResult CustomersList()
        {
           return View();
        }

        [HttpGet]
        public ActionResult CustomersListTable() 
        {
            var model = _HouseService.GetCustomers();

            return Json(new { data = model });
        }


        // GET: HouseController/Details/5
        public ActionResult Details(int id)
        {
            var model = _HouseService.GetHouseDetails(id);
            return View(model);
        }

        // GET: HouseController/Create
        public ActionResult AddHouse()
        {
            var model = _HouseService.CreateHouse();
            return View(model);
        }

        // POST: HouseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddHouse(int id,HouseViewModel model) 
        {
            try
            {
                bool result = _HouseService.AddHouse(model, id);
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

        // GET: HouseController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _HouseService.GetHouseDetails(id);
            return View(model);
        }

        // POST: HouseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HouseViewModel model)
        {
            try
            {
                bool result = _HouseService.UpdateHouse(model);
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

        

        // POST: HouseController/Delete/5
        [HttpDelete]
        
        public ActionResult Delete(int id)
        {
            try
            {
                bool result = _HouseService.DeleteHse(id);
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
