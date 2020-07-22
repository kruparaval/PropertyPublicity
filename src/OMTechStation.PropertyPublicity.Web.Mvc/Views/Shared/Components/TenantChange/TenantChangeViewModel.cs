using Abp.AutoMapper;
using OMTechStation.PropertyPublicity.Sessions.Dto;

namespace OMTechStation.PropertyPublicity.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
