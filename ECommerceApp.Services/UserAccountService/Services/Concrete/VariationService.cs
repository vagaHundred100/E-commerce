using AutoMapper;
using ECommerceApp.Domain.Entities;
using ECommerceApp.Domain.Repository;
using ECommerceApp.Infrastructure.DataBase.EntityFramework.EFRepository;
using ECommerceApp.Services.UserAccountService.DTOs;
using ECommerceApp.Services.UserAccountService.Services.Abstract;
using ECommerceApp.Shared.SharedRequestResults.Base;
using ECommerceApp.Shared.SharedRequestResults.SharedConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Services.UserAccountService.Services.Concrete
{
    public class VariationService : IVariationService
    {
        protected readonly IMapper _mapper;
        protected readonly IVariationRepository _repository;

        public VariationService(IVariationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public DefaultResult Create(VariationCreateDTO VariationDTO)
        {
            var Variation = _mapper.Map<Variation>(VariationDTO);
            _repository.Create(Variation);
            return new DefaultResult();
        }

        public DefaultResult Delete(int id)
        {
            var Variation = _repository.FindById(id);

            if (Variation == null)
            {
                throw new KeyNotFoundException(RequestResults.DataNotFound);
            }
            _repository.Delete(Variation);
            return new DefaultResult();
        }

        public DataResult<Variation> Get(int id)
        {
            var vt = _repository.FindById(id);
            return new DataResult<Variation>(vt);
        }

        public DataResult<List<Variation>> GetAll(int categoryTypeId)
        {
            var vtList = _repository.FindByCondition(c => c.CategoryTypeId == categoryTypeId).ToList();
            return new DataResult<List<Variation>>(vtList);
        }

        public DefaultResult Update(VariationUpdateDTO updateDTO)
        {
            var vt = _repository.FindById(updateDTO.Id);

            if (vt == null)
            {
                throw new KeyNotFoundException(RequestResults.DataNotFound);
            }

            _mapper.Map<VariationUpdateDTO, Variation>(updateDTO, vt);
            _repository.Update(vt);

            return new DefaultResult();
        }
    }
}

