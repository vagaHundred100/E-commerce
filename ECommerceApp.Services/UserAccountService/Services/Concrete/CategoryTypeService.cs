using ECommerceApp.Domain.Entities;
using ECommerceApp.Domain.Repository;
using ECommerceApp.Infrastructure.DataBase.EntityFramework.EFRepository;
using ECommerceApp.Services.UserAccountService.DTOs;
using ECommerceApp.Services.UserAccountService.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace ECommerceApp.Services.CategoryTypeService.Services.Concrete
{
    public class CategoryTypeService : ICategoryTypeService
    {
        protected readonly ICategoryTypeRepository _repository;

        public CategoryTypeService(ICategoryTypeRepository repository)
        {
            _repository = repository;
        }

        public void AddCategory(CategoryPostDTO dto)
        {
            CategoryType category = new CategoryType();
            category.Name = dto.Name;

            if(dto.ParentId == -1)
            {
                _repository.AddRoot(category);
            }
            else
            {
                category.ParentId = dto.ParentId;
                _repository.AddChild(category);
            }
        }

        public List<CategoryType> GetAllCategories()
        {
            return _repository.GetAllCategories().ToList();
        }

        public List<CategoryType> GetAllSubCategories(int parentId)
        {
            throw new NotImplementedException();
        }

        public CategoryType GetCategoryType(int id)
        {
            return _repository.Get(id);
        }

        public void RemoveCategory()
        {
            throw new NotImplementedException();
        }
    }
}
