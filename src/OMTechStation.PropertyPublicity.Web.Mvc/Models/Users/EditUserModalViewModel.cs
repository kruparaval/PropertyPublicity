using System.Collections.Generic;
using System.Linq;
using OMTechStation.PropertyPublicity.Roles.Dto;
using OMTechStation.PropertyPublicity.Users.Dto;

namespace OMTechStation.PropertyPublicity.Web.Models.Users
{
    public class EditUserModalViewModel
    {
        public UserDto User { get; set; }

        public IReadOnlyList<CountryDto> Roles { get; set; }

        public bool UserIsInRole(CountryDto role)
        {
            return User.RoleNames != null && User.RoleNames.Any(r => r == role.NormalizedName);
        }
    }
}
