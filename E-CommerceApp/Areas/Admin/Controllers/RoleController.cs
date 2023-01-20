using ECommerceApp.Services.UserAccountService.DTOs;
using ECommerceApp.Services.UserAccountService.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_CommerceApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly IAccountService _accountService;

        public RoleController(IAccountService service)
        {
            _accountService = service;
        }

        // GET: RoleController
        public ActionResult Index()
        {
            var response = _accountService.AllRoles();
            return View(response.Data);
        }

        // GET: RoleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RoleController/Create
        public ActionResult Create()
        {
            var role = new RoleDTO();
            return View(role);
        }

        // POST: RoleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoleDTO roleDTO)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.CreateRole(roleDTO);
                return  RedirectToAction("Index");
            }

            return BadRequest();
        }

        // GET: RoleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RoleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RoleDTO roleDTO)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.UpdateRole(id,roleDTO);
                return RedirectToAction("Index");
            }

            return BadRequest();
        }

        // GET: RoleController/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _accountService.GetRoleById(id);
            var roleDTO = new RoleDTO() { Id = id, Name = result.Data.Name };
            return View(roleDTO);
        }

        // POST: RoleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostDelete(RoleDTO roleDTO)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.DeleteRole(roleDTO);
                return RedirectToAction("Index");
            }

            return BadRequest();
        }
    }
}
