using System.Threading.Tasks;
using Abp.Application.Services;
using OMTechStation.PropertyPublicity.Sessions.Dto;

namespace OMTechStation.PropertyPublicity.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
