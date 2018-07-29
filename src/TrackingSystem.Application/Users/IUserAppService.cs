using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using TrackingSystem.Roles.Dto;
using TrackingSystem.Users.Dto;

namespace TrackingSystem.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
