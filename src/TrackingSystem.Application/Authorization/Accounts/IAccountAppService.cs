using System.Threading.Tasks;
using Abp.Application.Services;
using TrackingSystem.Authorization.Accounts.Dto;

namespace TrackingSystem.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
