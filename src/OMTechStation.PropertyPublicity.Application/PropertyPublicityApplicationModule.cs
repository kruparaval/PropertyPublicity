using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using OMTechStation.PropertyPublicity.Authorization;

namespace OMTechStation.PropertyPublicity
{
    [DependsOn(
        typeof(PropertyPublicityCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class PropertyPublicityApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<PropertyPublicityAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(PropertyPublicityApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
