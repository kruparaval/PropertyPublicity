using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using OMTechStation.PropertyPublicity.Configuration;
using OMTechStation.PropertyPublicity.Web;

namespace OMTechStation.PropertyPublicity.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class PropertyPublicityDbContextFactory : IDesignTimeDbContextFactory<PropertyPublicityDbContext>
    {
        public PropertyPublicityDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<PropertyPublicityDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            PropertyPublicityDbContextConfigurer.Configure(builder, configuration.GetConnectionString(PropertyPublicityConsts.ConnectionStringName));

            return new PropertyPublicityDbContext(builder.Options);
        }
    }
}
