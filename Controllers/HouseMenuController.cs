﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevenueApp.Controllers
{
    public class HouseMenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
