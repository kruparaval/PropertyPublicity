using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using OMTechStation.PropertyPublicity.Configuration.Dto;

namespace OMTechStation.PropertyPublicity.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : PropertyPublicityAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
