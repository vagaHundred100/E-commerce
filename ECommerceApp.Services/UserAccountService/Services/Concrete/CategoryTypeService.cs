using ECommerceApp.Domain.Entities;
using ECommerceApp.Domain.Repository;
using ECommerceApp.Infrastructure.DataBase.EntityFramework.EFRepository;
using ECommerceApp.Services.UserAccountService.DTOs;
using ECommerceApp.Services.UserAccountService.DTOs.Category;
using ECommerceApp.Services.UserAccountService.Services.Abstract;
using ECommerceApp.Shared.SharedRequestResults.Base;
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

        public DefaultResult Create(CategoryPostDTO dto)
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

            return new DefaultResult();
        }

        public DataResult<List<CategoryType>> GetAll()
        {
            var categories =  _repository.GetAllCategories().ToList();
            return new DataResult<List<CategoryType>>(categories);
        }

        public DataResult<List<CategoryType>> GetAllSubCategories(int parentId)
        {
            throw new NotImplementedException();
        }

        public DataResult<CategoryType> Get(int id)
        {
            var response =  _repository.Get(id);
            return new DataResult<CategoryType>(response);
        }

        public DefaultResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public DefaultResult Update(CategoryTypeUpdateDTO updateDTO)
        {
            throw new NotImplementedException();
        }
    }
}

