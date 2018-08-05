using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;
using TrackingSystem.Tracking.Obd;
using TrackingSystem.Tracking.ObdMasters.Dto;
using TrackingSystem.Tracking.Tasks.Dto;

namespace TrackingSystem.Tracking.Tasks.Service
{
    public interface IVehicleDataAppService : IApplicationService
    {
        Task<ListResultDto<VehicleData>> GetAll(GetAllVehiclesDataInput input);
        Task<VehicleData> Create(CreateVehicleDataDto input);
        Task<VehicleData> Get(int id);
    }    
}
