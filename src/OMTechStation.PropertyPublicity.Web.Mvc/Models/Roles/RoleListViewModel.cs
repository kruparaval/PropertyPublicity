using System.Collections.Generic;
using OMTechStation.PropertyPublicity.Roles.Dto;

namespace OMTechStation.PropertyPublicity.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
