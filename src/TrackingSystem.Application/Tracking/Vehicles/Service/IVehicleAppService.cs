using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;
using TrackingSystem.Tracking.Obd;
using TrackingSystem.Tracking.ObdMasters.Dto;
using TrackingSystem.Tracking.Tasks.Dto;

namespace TrackingSystem.Tracking.Tasks.Service
{
    public interface IVehicleAppService : IApplicationService
    {
        Task<ListResultDto<Vehicle>> GetAll(GetAllVehiclesInput input);
        Task<Vehicle> Create(CreateVehicleDto input);
        Task<Vehicle> Get(int id);
    }    
}
