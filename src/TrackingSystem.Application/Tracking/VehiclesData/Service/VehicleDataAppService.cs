using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using TrackingSystem.Tracking.ObdMasters.Dto;
using TrackingSystem.Tracking.Tasks.Dto;
using TrackingSystem.Tracking.Obd;
using Abp.Authorization;

namespace TrackingSystem.Tracking.Tasks.Service
{
    [AbpAuthorize]
    public class VehicleDataAppService : TrackingSystemAppServiceBase, IVehicleDataAppService
    {
        private readonly IRepository<VehicleData> Repository;

        public VehicleDataAppService(IRepository<VehicleData> repository)
        {
            Repository = repository;
        }

        public async Task<VehicleData> Create(CreateVehicleDataDto input)
        {
            var vehicle = ObjectMapper.Map<VehicleData>(input);
            vehicle.CreatorUserId = vehicle.LastModifierUserId = AbpSession.UserId.Value;
            vehicle.TenantId = AbpSession.TenantId.Value;
            return await Repository.InsertAsync(vehicle);
        }

        public async Task<ListResultDto<VehicleData>> GetAll(GetAllVehiclesDataInput input)
        {
            var data = await Repository
                .GetAll()
                .WhereIf(!string.IsNullOrEmpty(input.VehicleEngineNumber), t => t.VehicleEngineNumber == input.VehicleEngineNumber)
                .WhereIf(!string.IsNullOrEmpty(input.VehicleNumber), t => t.VehicleNumber == input.VehicleNumber)
                .OrderByDescending(t => t.CreationTime)
                .ToListAsync();

            return new ListResultDto<VehicleData>(
                ObjectMapper.Map<List<VehicleData>>(data));
        }

        public async Task<VehicleData> Get(int id)
        {
            return await Repository.GetAsync(id);
        }
    }
}
