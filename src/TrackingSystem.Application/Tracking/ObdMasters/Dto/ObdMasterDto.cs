using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using TrackingSystem.Tracking.Obd;

namespace TrackingSystem.Tracking.Tasks.Dto
{
    [AutoMapFrom(typeof(ObdMaster))]
    public class ObdMasterDto : EntityDto<int>
    {
    }   
}
