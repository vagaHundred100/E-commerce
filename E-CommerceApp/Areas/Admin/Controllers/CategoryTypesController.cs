using ECommerceApp.Domain.Entities;
using ECommerceApp.Services.UserAccountService.DTOs;
using ECommerceApp.Services.UserAccountService.Services.Abstract;
using ECommerceApp.Shared.SharedRequestResults.SharedConstants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_CommerceApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryTypeController : Controller
    {
        protected readonly ICategoryTypeService _categoryService;

        public CategoryTypeController(ICategoryTypeService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Get(int id)
        {
            if (ModelState.IsValid)
            {
                var response = _categoryService.Get(id);
                return StatusCode(200, response);

            }

            return BadRequest();
        }

        [HttpPost("CreateCategory")]
        public IActionResult CreateCategory(CategoryPostDTO postDTO)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Create(postDTO);
                return StatusCode(200);

            }

            return BadRequest();
        }

        public IActionResult GettAllCategories()
        {
            if (ModelState.IsValid)
            {
                var data = _categoryService.GetAll();
                return StatusCode(200, data);

            }

            return BadRequest();
        }
    }
}
