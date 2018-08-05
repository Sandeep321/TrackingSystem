using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrackingSystem.Tracking.Obd;
using TrackingSystem.Tracking.ObdMasters.Dto;
using TrackingSystem.Tracking.Tasks.Dto;

namespace TrackingSystem.Tracking.Tasks.Service
{
    public interface IObdMasterAppService : IApplicationService
    {
        Task<ListResultDto<ObdMaster>> GetAll(GetAllObdMasterInput input);
        Task<ObdMaster> Create(CreateObdMasterDto input);
    }    
}
