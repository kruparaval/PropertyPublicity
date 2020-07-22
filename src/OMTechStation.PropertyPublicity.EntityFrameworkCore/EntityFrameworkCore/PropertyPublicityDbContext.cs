using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using OMTechStation.PropertyPublicity.Authorization.Roles;
using OMTechStation.PropertyPublicity.Authorization.Users;
using OMTechStation.PropertyPublicity.MultiTenancy;

namespace OMTechStation.PropertyPublicity.EntityFrameworkCore
{
    public class PropertyPublicityDbContext : AbpZeroDbContext<Tenant, Role, User, PropertyPublicityDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public PropertyPublicityDbContext(DbContextOptions<PropertyPublicityDbContext> options)
            : base(options)
        {
        }
    }
}
