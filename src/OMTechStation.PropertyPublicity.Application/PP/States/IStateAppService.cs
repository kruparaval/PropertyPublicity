 using Abp.Application.Services;
using Abp.Application.Services.Dto;
using OMTechStation.PropertyPublicity.PP.States.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OMTechStation.PropertyPublicity.PP.States
{
    public interface IStateAppService : IAsyncCrudAppService<StateDto, int, PageStateResultRequestDto, CreateStateDto, StateDto>
    {

        Task<GetStateForEditOutput> GetStateForEdit(EntityDto input);
        Task<ListResultDto<StateListDto>> GetCountriesAsync(GetStateInput input);
    }
}

