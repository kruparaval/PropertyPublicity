using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace OMTechStation.PropertyPublicity.EntityFrameworkCore
{
    public static class PropertyPublicityDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<PropertyPublicityDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<PropertyPublicityDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
