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
    public class VehicleAppService : TrackingSystemAppServiceBase, IVehicleAppService
    {
        private readonly IRepository<Vehicle> Repository;

        public VehicleAppService(IRepository<Vehicle> repository)
        {
            Repository = repository;
        }

        public async Task<Vehicle> Create(CreateVehicleDto input)
        {
            var vehicle = ObjectMapper.Map<Vehicle>(input);
            vehicle.CreatorUserId = vehicle.LastModifierUserId = AbpSession.UserId.Value;
            return await Repository.InsertAsync(vehicle);
        }

        public async Task<ListResultDto<Vehicle>> GetAll(GetAllVehiclesInput input)
        {
            var tasks = await Repository
                .GetAll()
                .WhereIf(!string.IsNullOrEmpty(input.Type), t => t.Type == input.Type)
                .OrderByDescending(t => t.CreationTime)
                .ToListAsync();

            return new ListResultDto<Vehicle>(
                ObjectMapper.Map<List<Vehicle>>(tasks)
            );
        }

        public async Task<Vehicle> Get(int id)
        {
            return await Repository.GetAsync(id);
        }
    }
}
