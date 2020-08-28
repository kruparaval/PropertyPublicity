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
using OMTechStation.PropertyPublicity.PP.cities;

namespace OMTechStation.PropertyPublicity.PP.Cities.Dto
{
    public class CityAppService : AsyncCrudAppService<City, CityDto, int, PageCityResultRequestDto, CreateCityDto, CityDto>, ICityAppService
    {
        private readonly IRepository<City> _cityRepository;

        public CityAppService(IRepository<City> cityRepository) : base(cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public override async Task<CityDto> CreateAsync(CreateCityDto input)
        {
            var city = ObjectMapper.Map<City>(input);
            await Repository.InsertAsync(city);
            return MapToEntityDto(city);
        }

        protected override IQueryable<City> CreateFilteredQuery(PageCityResultRequestDto input)
        {
            return Repository.GetAll().WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Keyword));
        }

        protected override async Task<City> GetEntityByIdAsync(int id)
        {
            return await Repository.FirstOrDefaultAsync(x => x.Id == id);
        }

        protected override IQueryable<City> ApplySorting(IQueryable<City> query, PageCityResultRequestDto input) => query.OrderBy(s => s.Name);

        public async Task<GetCityForEditOutput> GetCityForEdit(EntityDto input)
        {
            var city = await _cityRepository.GetAsync(input.Id);
            var CityEditDto = ObjectMapper.Map<CityEditDto>(city);
            return new GetCityForEditOutput
            {
                City = CityEditDto
            };
        }

        public async Task<ListResultDto<CityListDto>> GetStatesAsync(GetCityInput input)
        {
            var city = await Repository.GetAll().Include(s => s.State).WhereIf(
                    !input.Filter.IsNullOrWhiteSpace(),
                    r => r.Name.Contains(input.Filter)
                ).ToListAsync();

            return new ListResultDto<CityListDto>(ObjectMapper.Map<List<CityListDto>>(city));
        }

        public Task<ListResultDto<CityListDto>> GetCityAsync(GetCityInput input)
        {
            throw new NotImplementedException();
        }
    }
}                                                                                                                                                               