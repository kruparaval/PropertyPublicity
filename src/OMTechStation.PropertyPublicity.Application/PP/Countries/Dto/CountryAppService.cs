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

namespace OMTechStation.PropertyPublicity.PP.Countries.Dto
{
    public class CountryAppService : AsyncCrudAppService<Country, CountryDto, int, PageCountryResultRequestDto, CreateCountryDto, CountryDto>, ICountryAppService
    {
        private readonly IRepository<Country> _countryRepository;
        public CountryAppService(IRepository<Country> countryRepository) : base(countryRepository)
        {
            _countryRepository = countryRepository;
        }
        public override async Task<CountryDto> CreateAsync(CreateCountryDto input)
        {
            var country = ObjectMapper.Map<Country>(input);
            //country.SetNormalizedName();
            //CheckErrors(await CreateAsync(Country));
            await Repository.InsertAsync(country);
            return MapToEntityDto(country);
        }

        protected override IQueryable<Country> CreateFilteredQuery(PageCountryResultRequestDto input)
        {
            return Repository.GetAll().WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Keyword));
        }

        protected override async Task<Country> GetEntityByIdAsync(int id)
        {
            return await Repository.FirstOrDefaultAsync(x => x.Id == id);
        }

        protected override IQueryable<Country> ApplySorting(IQueryable<Country> query, PageCountryResultRequestDto input) => query.OrderBy(s => s.Name);

        public async Task<GetCountryForEditOutput> GetCountryForEdit(EntityDto input)
        {
            var country = await _countryRepository.GetAsync(input.Id);
            var CountryEditDto = ObjectMapper.Map<CountryEditDto>(country);
            return new GetCountryForEditOutput
            {
                Country = CountryEditDto
            };
        }

        public async Task<ListResultDto<CountryListDto>> GetCountriesAsync(GetCountryInput input)
        {
            var roles = await Repository.GetAll().WhereIf(
                    !input.Filter.IsNullOrWhiteSpace(),
                    r => r.Name.Contains(input.Filter)
                ).ToListAsync();

            return new ListResultDto<CountryListDto>(ObjectMapper.Map<List<CountryListDto>>(roles));
        }
    }
}                                                                                                                                                               