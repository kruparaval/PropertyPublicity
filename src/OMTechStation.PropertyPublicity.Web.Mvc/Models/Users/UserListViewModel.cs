using System.Collections.Generic;
using OMTechStation.PropertyPublicity.Roles.Dto;

namespace OMTechStation.PropertyPublicity.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
