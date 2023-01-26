using ECommerceApp.Services.UserAccountService.DTOs;
using ECommerceApp.Services.UserAccountService.Services.Abstract;
using ECommerceApp.Shared.SharedRequestResults.Base;
using ECommerceApp.Shared.SharedRequestResults.SharedConstants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("Admin/[controller]")]
//[Authorize(Roles = AllowedRolesForController.ADMIN)]
public class AccountManegmentController : Controller
{
    private readonly IAccountService _accountService;

    public AccountManegmentController(IAccountService service)
    {
        _accountService = service;
    }

    public async Task<IActionResult> AssignUserToRole(UserRoleDTO userRole)
    {
        if (ModelState.IsValid)
        {
            var response = await _accountService.AssignUserToRole(userRole);
            return StatusCode(200, response);
        }
        return BadRequest();
    }

    public async Task<IActionResult> AssignUserToRoles(int UserId, List<int> roleIds)
    {
        if (ModelState.IsValid)
        {
            var response = await _accountService.AssignUserToRoles(UserId, roleIds);
            return StatusCode(200, response);
        }

        return BadRequest();
    }

    public async Task<IActionResult> UpdateUserRoles(int UserId, List<int> roleIds)
    {

        if (ModelState.IsValid)
        {
            var response = await _accountService.UpdateUserRoles(UserId, roleIds);
            return StatusCode(200, response);
        }

        return BadRequest();
    }

    public async Task<IActionResult> RemoveUserFromRole(int userId, int roleId)
    {
        if (ModelState.IsValid)
        {
            var response = await _accountService.RemoveUserFromRole(userId, roleId);
            return StatusCode(200, response);
        }

        return BadRequest();
    }

    [HttpGet("CreateRole")]
    public async Task<IActionResult> CreateRole(RoleDTO roleDTO) 
    {
        if (ModelState.IsValid)
        {
            var response = await _accountService.CreateRole(roleDTO);
            return StatusCode(200, response);
        }

        return BadRequest();
    }

    [HttpPost("GettAllUsers")]
    public IActionResult GettAllUsers(PaginationSettings settings)
    {
        if (ModelState.IsValid)
        {
            var response = _accountService.AllUsers(settings);
            return StatusCode(200, response);
        }

        return BadRequest();
    }
}