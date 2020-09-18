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
using OMTechStation.PropertyPublicity.PP.PropertyTypes.Dto;

namespace OMTechStation.PropertyPublicity.PP.Aminities.Dto
{
    public class AminityAppService : AsyncCrudAppService<Aminity, AminityDto, int, PageAminityResultRequestDto, CreateAminityDto, AminityDto>, IAminityAppService
    {
        private readonly IRepository<Aminity> _aminityRepository;
        public AminityAppService(IRepository<Aminity> aminityRepository) :base(aminityRepository)
        {
            _aminityRepository = aminityRepository;
        }

        protected override IQueryable<Aminity> CreateFilteredQuery(PageAminityResultRequestDto input)
        {
            return Repository.GetAll().WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Keyword));
        }

        protected override IQueryable<Aminity> ApplySorting(IQueryable<Aminity> query, PageAminityResultRequestDto input)
        {
            return (IQueryable<Aminity>)query.OrderBy(s => s.Name);
        }

        public async Task<GetAminityForEditOutput> GetAminityForEdit(EntityDto input)
        {
            var aminity = await _aminityRepository.GetAsync(input.Id);
            var AminityEditDto = ObjectMapper.Map<AminityEditDto>(aminity);
            return new GetAminityForEditOutput
            {
                Aminity = AminityEditDto,
            };
        }

        public async Task<ListResultDto<AminityListDto>> GetAminitiesAsync(GetAminityInput input)
        {
            var aminity = await Repository.GetAll().WhereIf(
                    !input.Filter.IsNullOrWhiteSpace(),
                    r => r.Name.Contains(input.Filter)
                ).ToListAsync();

            return new ListResultDto<AminityListDto> (ObjectMapper.Map<List<AminityListDto>>(aminity));
        }
    }
}