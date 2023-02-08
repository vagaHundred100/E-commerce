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
    public interface ICategoryTypeService
    {
        DataResult<CategoryType> Get(int id);
        DataResult<List<CategoryType>> GetAll();
        DefaultResult Delete(int id);
        DefaultResult Create(CategoryPostDTO CategoryTypeDTO);
        DefaultResult Update(CategoryTypeUpdateDTO updateDTO);
        DataResult<List<CategoryType>> GetAllSubCategories(int parentId);
    }
}
