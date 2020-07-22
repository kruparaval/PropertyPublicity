using Abp.AutoMapper;
using OMTechStation.PropertyPublicity.Roles.Dto;
using OMTechStation.PropertyPublicity.Web.Models.Common;

namespace OMTechStation.PropertyPublicity.Web.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class EditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool HasPermission(FlatPermissionDto permission)
        {
            return GrantedPermissionNames.Contains(permission.Name);
        }
    }
}
