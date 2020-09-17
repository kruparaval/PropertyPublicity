using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Linq.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OMTechStation.PropertyPublicity.Authorization.Roles;
using OMTechStation.PropertyPublicity.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OMTechStation.PropertyPublicity.PP.Cities;
using OMTechStation.PropertyPublicity.PP.PropertyTypes;
using Microsoft.AspNetCore.Mvc.Rendering;
using OMTechStation.PropertyPublicity.PP.States;

namespace OMTechStation.PropertyPublicity.PP.PropertyTypes.Dto
{
    public class PropertyTypeAppService : AsyncCrudAppService<PropertyType, PropertyTypeDto, int, PagePropertyTypeResultRequestDto, CreatePropertyTypeDto, PropertyTypeDto>, IPropertyTypeAppService
    {
        private readonly IRepository<PropertyType> _propertyTypeRepository;
        public PropertyTypeAppService(IRepository<PropertyType> propertyTypeRepository) :base(propertyTypeRepository)
        {
            _propertyTypeRepository = propertyTypeRepository;
        }

        protected override IQueryable<PropertyType> CreateFilteredQuery(PagePropertyTypeResultRequestDto input)
        {
            return Repository.GetAll().WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Keyword));
        }

        protected override IQueryable<PropertyType> ApplySorting(IQueryable<PropertyType> query, PagePropertyTypeResultRequestDto input)
        {
            return (IQueryable<PropertyType>)query.OrderBy(s => s.Name);
        }

        public async Task<GetPropertyTypeForEditOutput> GetPropertyTypeForEdit(EntityDto input)
        {
            var propertyType = await _propertyTypeRepository.GetAsync(input.Id);
            var PropertyTypeEditDto = ObjectMapper.Map<PropertyTypeEditDto>(propertyType);
            return new GetPropertyTypeForEditOutput
            {
                PropertyType = PropertyTypeEditDto,
            };
        }

        public async Task<ListResultDto<PropertyTypeListDto>> GetPropertyTypesAsync(GetPropertyTypeInput input)
        {
            var propertyType = await Repository.GetAll().WhereIf(
                    !input.Filter.IsNullOrWhiteSpace(),
                    r => r.Name.Contains(input.Filter)
                ).ToListAsync();

            return new ListResultDto<PropertyTypeListDto>(ObjectMapper.Map<List<PropertyTypeListDto>>(propertyType));
        }
    }
}