 using Abp.Application.Services;
using Abp.Application.Services.Dto;
using OMTechStation.PropertyPublicity.PP.Aminities.Dto;
using OMTechStation.PropertyPublicity.PP.Areas.Dto;
using OMTechStation.PropertyPublicity.PP.Cities.Dto;
using OMTechStation.PropertyPublicity.PP.PropertyTypes.Dto;
using OMTechStation.PropertyPublicity.PP.States.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OMTechStation.PropertyPublicity.PP.Aminities
{
    public interface IAminityAppService : IAsyncCrudAppService<Dto.AminityDto, int, PageAminityResultRequestDto, CreateAminityDto, Dto.AminityDto>
    {
        Task<GetAminityForEditOutput> GetAminityForEdit(EntityDto input);
        Task<ListResultDto<Dto.AminityListDto>> GetAminitiesAsync(GetAminityInput input);
    }
}



