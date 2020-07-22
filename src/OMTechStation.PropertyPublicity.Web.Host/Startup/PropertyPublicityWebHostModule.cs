using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using OMTechStation.PropertyPublicity.Configuration;

namespace OMTechStation.PropertyPublicity.Web.Host.Startup
{
    [DependsOn(
       typeof(PropertyPublicityWebCoreModule))]
    public class PropertyPublicityWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public PropertyPublicityWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PropertyPublicityWebHostModule).GetAssembly());
        }
    }
}
