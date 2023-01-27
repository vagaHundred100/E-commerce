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

namespace ECommerceApp.Services.UserAccountService.Services.Concrete
{
    public class VariationService : IVariationService
    {
        protected readonly IVariationRepository _repository;

        public VariationService(IVariationRepository repository)
        {
            _repository = repository;
        }

        public void Create(VariationCreateDTO variationDTO)
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

        public void Update(VariationUpdateDTO updateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
