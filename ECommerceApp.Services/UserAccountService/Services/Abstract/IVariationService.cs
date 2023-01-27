using ECommerceApp.Domain.Entities;
using ECommerceApp.Services.UserAccountService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Services.UserAccountService.Services.Abstract
{
    public interface IVariationService
    {
        Variation Get(int id);
        Variation GetAll();
        void Create(VariationCreateDTO variationDTO);
        void Delete(int id);
        void Update(VariationUpdateDTO updateDTO);
    }
}
