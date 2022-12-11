using Microsoft.AspNetCore.Mvc;

namespace E_CommerceApp.Areas.Admin.Controllers
{
    public class AccountManegmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
