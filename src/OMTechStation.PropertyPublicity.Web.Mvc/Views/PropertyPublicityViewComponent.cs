using Abp.AspNetCore.Mvc.ViewComponents;

namespace OMTechStation.PropertyPublicity.Web.Views
{
    public abstract class PropertyPublicityViewComponent : AbpViewComponent
    {
        protected PropertyPublicityViewComponent()
        {
            LocalizationSourceName = PropertyPublicityConsts.LocalizationSourceName;
        }
    }
}
