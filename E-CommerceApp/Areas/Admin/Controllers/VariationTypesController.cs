using ECommerceApp.Services.UserAccountService.DTOs;
using ECommerceApp.Services.UserAccountService.Services.Abstract;
using ECommerceApp.Shared.SharedRequestResults.Base;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_CommerceApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VariationTypesController : Controller
    {
        private readonly IVariationTypeService _variationTypeService;

        public VariationTypesController(IVariationTypeService variationTypeService)
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
            return StatusCode(200,response);
        }

        [HttpPost]
        public IActionResult Post([FromBody] VariationTypeCreateDTO vtDTO)
        {
            var response = _variationTypeService.Create(vtDTO);
            return StatusCode(200, response);
        }

        [HttpPut]
        public IActionResult Put(int id, [FromBody] VariationTypeUpdateDTO vtDTO)
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
