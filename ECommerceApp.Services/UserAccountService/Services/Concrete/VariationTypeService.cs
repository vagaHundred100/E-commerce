using ECommerceApp.Domain.Entities;
using ECommerceApp.Domain.Repository;
using ECommerceApp.Services.UserAccountService.DTOs;
using ECommerceApp.Services.UserAccountService.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Services.UserAccountService.Services.Concrete
{
    public class VariationTypeService : IVariationTypeService
    {
        protected readonly IVariationTypeRepository _repository;

        public VariationTypeService(IVariationTypeRepository repository)
        {
            _repository = repository;
        }

        public void Create(VariationTypeCreateDTO variationDTO)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Variation Get(int id)
        {
            throw new NotImplementedException();
        }

        public Variation GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(VariationTypeUpdateDTO updateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
