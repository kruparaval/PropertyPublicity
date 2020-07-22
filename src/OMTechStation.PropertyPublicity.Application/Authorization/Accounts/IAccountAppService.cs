using System.Threading.Tasks;
using Abp.Application.Services;
using OMTechStation.PropertyPublicity.Authorization.Accounts.Dto;

namespace OMTechStation.PropertyPublicity.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
