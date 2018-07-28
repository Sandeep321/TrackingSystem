using Abp.Application.Services;
using Abp.Application.Services.Dto;
using TrackingSystem.MultiTenancy.Dto;

namespace TrackingSystem.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
