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
    public interface IVariationService
    {
        DataResult<Variation> Get(int id);
        DataResult<List<Variation>> GetAll(int variationId);
        DefaultResult Delete(int id);
        DefaultResult Create(VariationCreateDTO variationDTO);
        DefaultResult Update(VariationUpdateDTO updateDTO);
    }
}
