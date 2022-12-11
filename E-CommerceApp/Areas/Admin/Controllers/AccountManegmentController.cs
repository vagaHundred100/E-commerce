using ECommerceApp.Services.UserAccountService.DTOs;
using ECommerceApp.Services.UserAccountService.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Threading.Tasks;


[Authorize(Roles = "Admin")]
[ApiController]
[Route("[controller]")]
public class AccountManegmentController : Controller
{
    private readonly IAccountService _accountService;

    public AccountManegmentController(IAccountService service)
    {
        _accountService = service;
    }

}



