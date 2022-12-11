using ECommerceApp.Services.UserAccountService.DTOs;
using ECommerceApp.Services.UserAccountService.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Threading.Tasks;


[Authorize(Roles = "Admin")]
[ApiController]
[Route("[controller]")]
public class AccountController : Controller
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService service)
    {
        _accountService = service;
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

    [HttpPost("ChangePasssword")]
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
    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginDTO model)
    {
        if (ModelState.IsValid)
        {
            var response = await _accountService.Login(model);
            return StatusCode(200, response);
        }

        return BadRequest();
    }

    [HttpPost("Deactivate")]
    public async Task<IActionResult> Deactivate(int Id)
    {
        if (ModelState.IsValid)
        {
            var response = await _accountService.DeactivateUser(Id);
            return StatusCode(200, response);
        }

        return BadRequest();
    }

    [HttpPost("Activate")]
    public async Task<IActionResult> Activate(int Id)
    {
        if (ModelState.IsValid)
        {
            var response = await _accountService.ActivateUser(Id);
            return StatusCode(200, response);

        }

        return BadRequest();
    }

    [AllowAnonymous]
    [HttpPost("Register")]
    public async Task<IActionResult> Register(UserCreateDTO model)
    {
        if (ModelState.IsValid)
        {
            var response = await _accountService.RegisterUser(model);
            return StatusCode(200, response);
        }

        return BadRequest();
    }
}


