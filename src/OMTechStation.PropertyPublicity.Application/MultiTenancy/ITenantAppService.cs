using Abp.Application.Services;
using OMTechStation.PropertyPublicity.MultiTenancy.Dto;

namespace OMTechStation.PropertyPublicity.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

