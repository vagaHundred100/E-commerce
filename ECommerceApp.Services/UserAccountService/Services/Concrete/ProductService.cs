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
    public class ProductService : IProductService
    {
        protected readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public void Create(ProductCreateDTO variationDTO)
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
