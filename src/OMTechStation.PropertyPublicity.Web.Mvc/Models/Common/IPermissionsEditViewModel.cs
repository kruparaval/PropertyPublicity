using System.Collections.Generic;
using OMTechStation.PropertyPublicity.Roles.Dto;

namespace OMTechStation.PropertyPublicity.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}