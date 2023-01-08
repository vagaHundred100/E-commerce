using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceApp.Controllers
{
    public class SiteController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
