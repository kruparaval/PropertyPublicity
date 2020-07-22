using Abp.Application.Services.Dto;

namespace OMTechStation.PropertyPublicity.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

