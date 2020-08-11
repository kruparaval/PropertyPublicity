using OMTechStation.PropertyPublicity.Roles.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace OMTechStation.PropertyPublicity.PP.States.Dto
{
    public class GetStateForEditOutput
    {
        public StateEditDto Country { get; set; }

        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
        public StateEditDto State { get; internal set; }
    }
}
