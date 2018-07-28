using System.Threading.Tasks;
using Abp.Application.Services;
using TrackingSystem.Sessions.Dto;

namespace TrackingSystem.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
