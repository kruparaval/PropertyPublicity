using OMTechStation.PropertyPublicity.Roles.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMTechStation.PropertyPublicity.Web.PP.Models.Cities
{
    public class CityListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }

    }
}
