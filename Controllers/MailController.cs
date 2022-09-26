using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RevenueApp.Models.Data;
using RevenueApp.Models.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevenueApp.Controllers
{
    public class MailController : Controller
    {
        private MailService _MailService;
        private UserManager<ApplicationUser> _UserManager;
        public MailController(MailService mailService, UserManager<ApplicationUser> userManager)
        {
            _MailService = mailService;
            _UserManager = userManager;
        }

        // GET: MailController
        public async Task<ActionResult> IndexAsync()
        {
            //var user = await _UserManager.GetUserAsync(User);
            //await _MailService.SendReceiptByEmailAsync(user, 10);
            return View();

        }

        // GET: MailController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MailController/Create
        public ActionResult SendReceipt() 
        {
            return View();
        }

        // POST: MailController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendReceipt(IFormCollection collection)
        {
            try
            {
                //var user = await _UserManager.GetUserAsync(User);
                // await _MailService.SendReceiptByEmailAsync(user, 10);

                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: MailController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MailController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: MailController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MailController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }
    }
}
