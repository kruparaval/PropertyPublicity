 using Abp.Application.Services;
using Abp.Application.Services.Dto;
using OMTechStation.PropertyPublicity.PP.Areas.Dto;
using OMTechStation.PropertyPublicity.PP.Cities.Dto;
using OMTechStation.PropertyPublicity.PP.States.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OMTechStation.PropertyPublicity.PP.Areas
{
    public interface IAreaAppService : IAsyncCrudAppService<AreaDto, int, PageAreaResultRequestDto, CreateAreaDto, AreaDto>
    {
        Task<GetAreaForEditOutput> GetAreaForEdit(EntityDto input);
        Task<ListResultDto<Dto.AreaListDto>> GetAreasAsync(GetAreaInput input);
    }
}



