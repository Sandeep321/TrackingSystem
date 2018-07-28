using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using TrackingSystem.Configuration.Dto;

namespace TrackingSystem.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : TrackingSystemAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
