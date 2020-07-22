using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using OMTechStation.PropertyPublicity.Configuration;

namespace OMTechStation.PropertyPublicity.Web.Startup
{
    [DependsOn(typeof(PropertyPublicityWebCoreModule))]
    public class PropertyPublicityWebMvcModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public PropertyPublicityWebMvcModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<PropertyPublicityNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PropertyPublicityWebMvcModule).GetAssembly());
        }
    }
}
