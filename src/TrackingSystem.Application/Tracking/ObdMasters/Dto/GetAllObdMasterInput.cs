using static TrackingSystem.Tracking.Obd.ObdMaster;

namespace TrackingSystem.Tracking.Tasks.Dto
{
    public class GetAllObdMasterInput
    {
        public ObdType? Type { get; set; }
    }
}
