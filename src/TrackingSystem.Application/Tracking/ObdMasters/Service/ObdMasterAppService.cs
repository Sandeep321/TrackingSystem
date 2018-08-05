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
            var obdMaster = ObjectMapper.Map<ObdMaster>(input);
            obdMaster.CreatorUserId = obdMaster.LastModifierUserId = AbpSession.UserId.Value;
            return await _obdRepository.InsertAsync(obdMaster);
        }

        public async Task<ListResultDto<ObdMaster>> GetAll(GetAllObdMasterInput input)
        {
            var tasks = await _obdRepository
                .GetAll()
                .WhereIf(!string.IsNullOrEmpty(input.Type), t => t.Type == input.Type)
                .WhereIf(!string.IsNullOrEmpty(input.Protocol), t => t.Protocol == input.Protocol)
                .OrderByDescending(t => t.CreationTime)
                .ToListAsync();

            return new ListResultDto<ObdMaster>(
                ObjectMapper.Map<List<ObdMaster>>(tasks)
            );
        }

        public async Task<ObdMaster> Get(int id)
        {
            return await _obdRepository.GetAsync(id);
        }

        //public async Task<ObdMaster> Update(ObdMasterDto input)
        //{
        //    //await _obdRepository.InsertOrUpdateAndGetIdAsync(input);
        //   var obd = await  _obdRepository.GetAsync(input.Id);
        //    ObjectMapper.Map(input, obd);
        //    return await _obdRepository.UpdateAsync(obd);            
        //}

        //public async Task<ObdMaster> Delete(int id)
        //{
        //    //await _obdRepository.InsertOrUpdateAndGetIdAsync(input);
        //    //var obd = await _obdRepository.GetAsync(input.Id);
        //    //ObjectMapper.Map(input, obd);
        //    return await _obdRepository.DeleteAsync(id);
        //}
    }
}
