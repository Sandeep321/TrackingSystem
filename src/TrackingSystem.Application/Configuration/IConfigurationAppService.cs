using System.Threading.Tasks;
using TrackingSystem.Configuration.Dto;

namespace TrackingSystem.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
