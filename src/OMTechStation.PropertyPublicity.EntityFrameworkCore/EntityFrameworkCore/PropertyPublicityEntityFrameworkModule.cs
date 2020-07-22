using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using OMTechStation.PropertyPublicity.EntityFrameworkCore.Seed;

namespace OMTechStation.PropertyPublicity.EntityFrameworkCore
{
    [DependsOn(
        typeof(PropertyPublicityCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class PropertyPublicityEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<PropertyPublicityDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        PropertyPublicityDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        PropertyPublicityDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PropertyPublicityEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
