using AutoMapper;
using ECommerceApp.Domain.Entities;
using ECommerceApp.Domain.Repository;
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
    public class VariationTypeService : IVariationTypeService
    {
        protected readonly IMapper _mapper;
        protected readonly IVariationTypeRepository _repository;

        public VariationTypeService(IVariationTypeRepository repository,
                                    IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public DefaultResult Create(VariationTypeCreateDTO variationTypeDTO)
        {
            var variationType = _mapper.Map<VariationType>(variationTypeDTO);
            _repository.Create(variationType);
            return new DefaultResult();
        }

        public DefaultResult Delete(int id)
        {
            var variationType = _repository.FindById(id);

            if (variationType == null)
            {
                throw new KeyNotFoundException( RequestResults.DataNotFound);
            }
            _repository.Delete(variationType);
            return new DefaultResult();
        }

        public DataResult<VariationType> Get(int id)
        {
            var vt = _repository.FindById(id);
            return new DataResult<VariationType>(vt);
        }

        public DataResult<List<VariationType>> GetAll(int variationId)
        {
            var vtList =  _repository.FindByCondition(c=>c.VariationId == variationId).ToList();
            return new DataResult<List<VariationType>>(vtList);
        }

        public DefaultResult Update(VariationTypeUpdateDTO updateDTO)
        {
            var vt =  _repository.FindById(updateDTO.Id);

            if (vt == null)
            {
                throw new KeyNotFoundException(RequestResults.DataNotFound);
            }

            _mapper.Map<VariationTypeUpdateDTO,VariationType>(updateDTO,vt);
            _repository.Update(vt);

            return new DefaultResult();
        }
    }
}
