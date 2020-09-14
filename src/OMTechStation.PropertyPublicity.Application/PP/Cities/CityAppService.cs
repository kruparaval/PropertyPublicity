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
using Microsoft.AspNetCore.Mvc.Rendering;
using OMTechStation.PropertyPublicity.PP.States;

namespace OMTechStation.PropertyPublicity.PP.Cities.Dto
{
    public class CityAppService : AsyncCrudAppService<City, CityDto, int, PageCityResultRequestDto, CreateCityDto, CityDto>, ICityAppService
    {
        private readonly IRepository<State> _stateRepository;
        private readonly IRepository<City> _cityRepository;

        public CityAppService(IRepository<City> cityRepository,
            IRepository<State> stateRepository) : base(cityRepository)
        {
            _stateRepository = stateRepository;
            _cityRepository = cityRepository;
        }

        protected override IQueryable<City> CreateFilteredQuery(PageCityResultRequestDto input)
        {
            return Repository.GetAll().Include(s => s.State).WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Keyword));
        }

        protected override IQueryable<City> ApplySorting(IQueryable<City> query, PageCityResultRequestDto input)
        {
            return (IQueryable<City>)query.OrderBy(s => s.Name);
        }

        public async Task<GetCityForEditOutput> GetCityForEdit(EntityDto input)
        {
            var city = await _cityRepository.GetAsync(input.Id);
            var states = _stateRepository.GetAll().Select(s => new SelectListItem() { Text = s.Name, Value = s.Id.ToString() }).ToList();
            var CityEditDto = ObjectMapper.Map<CityEditDto>(city);
            return new GetCityForEditOutput
            {
                City = CityEditDto,
                States = states,
               
            };
        }

        public async Task<ListResultDto<AreaListDto>> GetCitiesAsync(GetCityInput input)
        {
            var city = await Repository.GetAll().Include(s => s.State).WhereIf(
                    !input.Filter.IsNullOrWhiteSpace(),
                    r => r.Name.Contains(input.Filter)
                ).ToListAsync();

            return new ListResultDto<AreaListDto>(ObjectMapper.Map<List<AreaListDto>>(city));
        }
    }
}