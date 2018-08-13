using static TrackingSystem.Tracking.Obd.ObdMaster;

namespace TrackingSystem.Tracking.Tasks.Dto
{
    public class GetAllObdMasterInput
    {
        public string Type { get; set; }
        public string Protocol { get; set; }
    }
}
