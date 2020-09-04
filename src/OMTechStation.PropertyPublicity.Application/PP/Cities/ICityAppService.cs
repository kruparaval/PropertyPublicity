 using Abp.Application.Services;
using Abp.Application.Services.Dto;
using OMTechStation.PropertyPublicity.PP.Cities.Dto;
using OMTechStation.PropertyPublicity.PP.States.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OMTechStation.PropertyPublicity.PP.States
{
    public interface ICityAppService : IAsyncCrudAppService<CityDto, int, PageCityResultRequestDto, CreateCityDto, CityDto>
    {
        Task<GetCityForEditOutput> GetCityForEdit(EntityDto input);
        Task<ListResultDto<CityListDto>> GetCitiesAsync(GetCityInput input);
    }
}



