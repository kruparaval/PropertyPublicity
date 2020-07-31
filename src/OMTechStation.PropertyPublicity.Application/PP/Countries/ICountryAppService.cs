using Abp.Application.Services;
using Abp.Application.Services.Dto;
using OMTechStation.PropertyPublicity.PP.Countries.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OMTechStation.PropertyPublicity.PP.Countries
{
    public interface ICountryAppService : IAsyncCrudAppService<CountryDto, int, PageCountryResultRequestDto, CreateCountryDto, CountryDto>
    {

        Task<GetCountryForEditOutput> GetCountryForEdit(EntityDto input);
        Task<ListResultDto<CountryListDto>> GetCountriesAsync(GetCountryInput input);
    }
}
