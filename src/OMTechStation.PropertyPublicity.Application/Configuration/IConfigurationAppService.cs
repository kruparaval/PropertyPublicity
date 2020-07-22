using System.Threading.Tasks;
using OMTechStation.PropertyPublicity.Configuration.Dto;

namespace OMTechStation.PropertyPublicity.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
