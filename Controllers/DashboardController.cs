using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevenueApp.Controllers
{
    public class DashboardController :Controller
    {
        // GET: DashboardController
        public ActionResult Index()
        {
            return View();
        }

       
        // GET: DashboardController/Create
        public ActionResult AdminDashboard()
        {
            return View();
        }

        // POST: DasbboardController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminDashboard(IFormCollection collection)
        {
            try
            {
                return View();
            }
            catch
            {
                return View();
            }
        }
         // GET: DasbboardController/Create
        public ActionResult OfficerDashboard()
        {
            return View();
        }

        // POST: DasbboardController/Create 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OfficerDashboard(IFormCollection collection)
        {
            try
            {
                return View();
            }
            catch
            {
                return View();
            }
        }

       
    }
}
