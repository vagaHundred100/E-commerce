using ECommerceApp.Services.UserAccountService.Services.Abstract;
using ECommerceApp.Shared.SharedRequestResults.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {

        private readonly IAccountService _accountService;

        public UserController(IAccountService service)
        {
            _accountService = service;
        }
        public IActionResult Index()
        {
            PaginationSettings settings = new PaginationSettings();

            var response = _accountService.AllUsers(settings);
            var data = response.Data;
            return View(data);
        }




    }
}
