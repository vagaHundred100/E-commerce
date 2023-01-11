using ECommerceApp.Services.UserAccountService.DTOs;
using ECommerceApp.Services.UserAccountService.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Threading.Tasks;



public class AccountController : Controller
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService service)
    {
        _accountService = service;
    }



    [AllowAnonymous]
    public IActionResult ResetPassword()
    {
        return View();
    }

    [HttpPost("ResetPassword")]
    public async Task<IActionResult> ResetPasswordAsync(UserResetPasswordDTO model)
    {
        if (ModelState.IsValid)
        {
            var response = await _accountService.ResetPassword(model);
            return StatusCode(200, response);

        }

        return BadRequest();

    }

    [AllowAnonymous]
    public IActionResult ChangePassword()
    {
       return View();
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> ChangePassword(UserChangePasswordDTO model)
    {
        if (ModelState.IsValid)
        {
            var response = await _accountService.ChangePassword(model);
            return StatusCode(200, response);
        }

        return BadRequest();
    }

    [AllowAnonymous]
    public IActionResult Login()
    {
        return View();
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Login(LoginDTO model)
    {
        if (ModelState.IsValid)
        {
            var response = await _accountService.Login(model);
            return StatusCode(200, response);
        }

        return View(model);
    }

    [AllowAnonymous]
    public IActionResult Register()
    {
        return View();
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Register(RegisterDTO model)
    {
        if (ModelState.IsValid)
        {
            var response = await _accountService.RegisterUser(model);
            return StatusCode(200, response);
        }

        return BadRequest();
    }
}


