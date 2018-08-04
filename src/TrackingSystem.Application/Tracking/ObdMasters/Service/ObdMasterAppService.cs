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
    public class ObdMasterAppService : TrackingSystemAppServiceBase, IObdMasterAppService
    {
        private readonly IRepository<ObdMaster> _obdRepository;

        public ObdMasterAppService(IRepository<ObdMaster> repository)
        {
            _obdRepository = repository;
        }

        public async Task<ObdMaster> Create(CreateObdMasterDto input)
        {
            var task = ObjectMapper.Map<ObdMaster>(input);
            task.CreatorUserId = task.LastModifierUserId = AbpSession.UserId.Value;           
            return await _obdRepository.InsertAsync(task);
        }

        public async Task<ListResultDto<ObdMaster>> GetAll(GetAllObdMasterInput input)
        {
            var tasks = await _obdRepository
                .GetAll()
                .WhereIf(input.Type.HasValue, t => t.Type == input.Type.Value)
                .OrderByDescending(t => t.CreationTime)
                .ToListAsync();

            return new ListResultDto<ObdMaster>(
                ObjectMapper.Map<List<ObdMaster>>(tasks)
            );
        }
    }
}
