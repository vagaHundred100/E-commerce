using ECommerceApp.Services.UserAccountService.DTOs;
using ECommerceApp.Services.UserAccountService.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VariationController : Controller
    {
        private readonly IVariationService _variationTypeService;

        public VariationController(IVariationService variationTypeService)
        {
            _variationTypeService = variationTypeService;
        }

        public IActionResult GetAll(int id)
        {
            var response = _variationTypeService.GetAll(id);
            return StatusCode(200, response);
        }

        public IActionResult Get(int id)
        {
            var response = _variationTypeService.Get(id);
            return StatusCode(200, response);
        }

        [HttpPost]
        public IActionResult Post([FromBody] VariationCreateDTO vtDTO)
        {
            var response = _variationTypeService.Create(vtDTO);
            return StatusCode(200, response);
        }

        [HttpPut]
        public IActionResult Put(int id, [FromBody] VariationUpdateDTO vtDTO)
        {
            var response = _variationTypeService.Update(vtDTO);
            return StatusCode(200, response);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var response = _variationTypeService.Delete(id);
            return StatusCode(200, response);
        }
    }
}
