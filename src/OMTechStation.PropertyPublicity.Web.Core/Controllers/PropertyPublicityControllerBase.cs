using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace OMTechStation.PropertyPublicity.Controllers
{
    public abstract class PropertyPublicityControllerBase: AbpController
    {
        protected PropertyPublicityControllerBase()
        {
            LocalizationSourceName = PropertyPublicityConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
