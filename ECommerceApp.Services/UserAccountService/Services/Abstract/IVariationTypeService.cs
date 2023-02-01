using ECommerceApp.Domain.Entities;
using ECommerceApp.Services.UserAccountService.DTOs;
using ECommerceApp.Shared.SharedRequestResults.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Services.UserAccountService.Services.Abstract
{
    public interface IVariationTypeService
    {
        DataResult<VariationType> Get(int id);
        DataResult<List<VariationType>> GetAll(int variationId);
        DefaultResult Delete(int id);
        DefaultResult Create(VariationTypeCreateDTO variationDTO);
        DefaultResult Update(VariationTypeUpdateDTO updateDTO);
    }
}
