﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Admin1Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
