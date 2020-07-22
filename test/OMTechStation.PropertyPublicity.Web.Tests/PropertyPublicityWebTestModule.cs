using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using OMTechStation.PropertyPublicity.EntityFrameworkCore;
using OMTechStation.PropertyPublicity.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace OMTechStation.PropertyPublicity.Web.Tests
{
    [DependsOn(
        typeof(PropertyPublicityWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class PropertyPublicityWebTestModule : AbpModule
    {
        public PropertyPublicityWebTestModule(PropertyPublicityEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PropertyPublicityWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(PropertyPublicityWebMvcModule).Assembly);
        }
    }
}