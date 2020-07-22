using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace OMTechStation.PropertyPublicity.Web.Views
{
    public abstract class PropertyPublicityRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected PropertyPublicityRazorPage()
        {
            LocalizationSourceName = PropertyPublicityConsts.LocalizationSourceName;
        }
    }
}
