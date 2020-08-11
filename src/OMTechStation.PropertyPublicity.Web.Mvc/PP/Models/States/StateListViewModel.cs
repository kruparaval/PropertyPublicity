using OMTechStation.PropertyPublicity.Roles.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMTechStation.PropertyPublicity.Web.PP.Models.States
{
    public class StateListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }

    }
}
