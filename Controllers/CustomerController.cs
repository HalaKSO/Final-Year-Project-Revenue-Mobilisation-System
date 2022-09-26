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
    public class CustomerController : Controller 
    {
        private readonly CustomerService _CustomerService;
        private readonly RevenueDBContext _Context;
        public CustomerController(CustomerService customerService, RevenueDBContext context)
        {
            _CustomerService = customerService;
            _Context = context;
        }
        // GET: Controller
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CustomerList()
        {
            var model = _CustomerService.GetCustomers();

            return Json(new { data = model });
        }

        // GET: CustomerController/Details/5
        public ActionResult CustomerDetails(int id)
        {
            var model = _CustomerService.GetCutomersDetails(id);
            return View(model);
        }

        // GET: CustomerController/Create
        public ActionResult AddCustomer()
        {
            var model = _CustomerService.CreateCustomer();
            return View(model);
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCustomer(CustomerViewModel model)
        {
            try
            {

                bool result = _CustomerService.AddCustomer(model);
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

        // GET: CustomerController/Edit/5
        public ActionResult UpdateCustomer(int id)
        {
            var model = _CustomerService.GetCutomersDetails(id);
            return View(model);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateCustomer(CustomerViewModel model)
        {
            try
            {
                bool result = _CustomerService.UpdateCustomer(model);
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
       
        public ActionResult RemoveCustomer(int id)
        {
            try
            {
                bool result = _CustomerService.DeleteCustomer(id);
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
