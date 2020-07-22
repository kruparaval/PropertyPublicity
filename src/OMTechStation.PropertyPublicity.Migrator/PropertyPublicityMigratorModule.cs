using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using OMTechStation.PropertyPublicity.Configuration;
using OMTechStation.PropertyPublicity.EntityFrameworkCore;
using OMTechStation.PropertyPublicity.Migrator.DependencyInjection;

namespace OMTechStation.PropertyPublicity.Migrator
{
    [DependsOn(typeof(PropertyPublicityEntityFrameworkModule))]
    public class PropertyPublicityMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public PropertyPublicityMigratorModule(PropertyPublicityEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(PropertyPublicityMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                PropertyPublicityConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PropertyPublicityMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
