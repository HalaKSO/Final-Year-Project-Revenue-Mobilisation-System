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
    public class BusinessController : Controller 
    {
        private readonly BusinessService _BusinessService;
        private readonly RevenueDBContext _Context;
       
        public BusinessController(BusinessService businessService, RevenueDBContext context)
        {
            _BusinessService = businessService;
            _Context = context;
        }
        // GET: BusinessController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BusinessList()
        {
            var model = _BusinessService.GetBusinesses();
            return Json(new { data = model });
        }

        //show first

        public ActionResult CustomersList()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CustomersListTable()
        {
            var model = _BusinessService.GetCustomers();

            return Json(new { data = model });
        }


        // GET: BusinessController/Details/5
        public ActionResult Details(int id)
        {
            var model = _BusinessService.GetBusinessDetails(id);
            return View(model);
        }

        // GET: BusinessController/Create
        public ActionResult AddBusiness() 
        {
            var model = _BusinessService.CreateBusiness();
            return View(model);
        }

        // POST: BusinessController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBusiness(BusinessViewModel model,int id)
        {
            try
            {
                bool result = _BusinessService.AddBusiness(model,id);
                if (result == true)
                {
                    return RedirectToAction(nameof(CustomersList));
                }
                throw new Exception();
            }
            catch
            {
                return View();
            }
        }

        // GET: BusinessController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _BusinessService.GetBusinessDetails(id);
            return View(model);
        }

        // POST: BusinessController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BusinessViewModel model)
        {
            try
            {
                bool result = _BusinessService.UpdateBuisness(model);
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

       
        // POST: BusinessController/Delete/5
        [HttpDelete]
        
        public ActionResult Delete(int id)
        {
            try
            {
                bool result = _BusinessService.DeleteBusiness(id);
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
