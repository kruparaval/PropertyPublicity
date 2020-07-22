using Abp.MultiTenancy;
using OMTechStation.PropertyPublicity.Authorization.Users;

namespace OMTechStation.PropertyPublicity.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
