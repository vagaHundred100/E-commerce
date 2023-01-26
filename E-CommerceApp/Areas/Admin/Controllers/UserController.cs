using ECommerceApp.Services.UserAccountService.DTOs;
using ECommerceApp.Services.UserAccountService.Services.Abstract;
using ECommerceApp.Shared.SharedRequestResults.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        [HttpGet("AssignUserToRole")]
        public async Task<IActionResult> AssignUserToRole(int id)
        {
            var roleList = new List<SelectListItem>();
            var response = _accountService.AllRoles();
            var roles = response.Data;

            for (int i = 0; i < roles.Count; i++)
            {
                roleList.Add(new SelectListItem { Value = roles[i].Id.ToString(), Text = roles[i].Name });
            }

            ViewBag.roles = roleList;

            var userRoleDTO = new UserRoleDTO { UserId=id };
            return View(userRoleDTO);
        }

        [HttpPost("AssignUserToRole")]
        public async Task<IActionResult> AssignUserToRole(UserRoleDTO userRole)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.AssignUserToRole(userRole);
                return StatusCode(200, response);
            }
            return BadRequest();
        }




    }
}
