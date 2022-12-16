using ECommerceApp.Domain.Entities;
using ECommerceApp.Services.UserAccountService.DTOs;
using ECommerceApp.Services.UserAccountService.Services.Abstract;
using ECommerceApp.Shared.SharedRequestResults.SharedConstants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_CommerceApp.Areas.Admin.Controllers
{
    [ApiController]
    [Route("Admin/[controller]")]
    public class CategoryController : Controller
    {
        protected readonly ICategoryTypeService _categoryService;

        public CategoryController(ICategoryTypeService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult GetGategory(int id)
        {
            if (ModelState.IsValid)
            {
                var response =  _categoryService.GetCategoryType(id);
                return StatusCode(200, response);

            }

            return BadRequest();
        }

        [HttpPost("CreateCategory")]
        public IActionResult CreateCategory(CategoryPostDTO postDTO)
        {
            if (ModelState.IsValid)
            {
                _categoryService.AddCategory(postDTO);
                return StatusCode(200);

            }

            return BadRequest();
        }

        public IActionResult GettAllCategories()
        {
            if (ModelState.IsValid)
            {
                var data = _categoryService.GetAllCategories();
                return StatusCode(200, data);

            }

            return BadRequest();
        }
    }
}
