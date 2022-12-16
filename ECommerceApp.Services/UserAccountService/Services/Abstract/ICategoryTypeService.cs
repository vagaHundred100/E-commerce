using ECommerceApp.Domain.Entities;
using ECommerceApp.Services.UserAccountService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Services.UserAccountService.Services.Abstract
{
    public interface ICategoryTypeService
    {
        void AddCategory(CategoryPostDTO dto);
        void RemoveCategory();
        CategoryType GetCategoryType(int id);
        List<CategoryType> GetAllCategories();
        List<CategoryType> GetAllSubCategories(int parentId);

    }
}
