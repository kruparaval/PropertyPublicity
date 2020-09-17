 using Abp.Application.Services;
using Abp.Application.Services.Dto;
using OMTechStation.PropertyPublicity.PP.Areas.Dto;
using OMTechStation.PropertyPublicity.PP.Cities.Dto;
using OMTechStation.PropertyPublicity.PP.PropertyTypes.Dto;
using OMTechStation.PropertyPublicity.PP.States.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OMTechStation.PropertyPublicity.PP.PropertyTypes
{
    public interface IPropertyTypeAppService : IAsyncCrudAppService<PropertyTypeDto, int, PagePropertyTypeResultRequestDto, CreatePropertyTypeDto, PropertyTypeDto>
    {
        Task<GetPropertyTypeForEditOutput> GetPropertyTypeForEdit(EntityDto input);
        Task<ListResultDto<Dto.PropertyTypeListDto>> GetPropertyTypesAsync(GetPropertyTypeInput input);
    }
}



