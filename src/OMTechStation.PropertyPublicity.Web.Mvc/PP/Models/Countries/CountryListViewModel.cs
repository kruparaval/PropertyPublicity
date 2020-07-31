using OMTechStation.PropertyPublicity.Roles.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMTechStation.PropertyPublicity.Web.PP.Models.Countries
{
    public class CountryListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }

    }
}
