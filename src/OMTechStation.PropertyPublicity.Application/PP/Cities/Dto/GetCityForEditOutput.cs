using OMTechStation.PropertyPublicity.Roles.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace OMTechStation.PropertyPublicity.PP.Cities.Dto
{
    public class GetCityForEditOutput
    {
        public CityEditDto City { get; set; }

        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
        public CityEditDto State { get; internal set; }
    }
}
