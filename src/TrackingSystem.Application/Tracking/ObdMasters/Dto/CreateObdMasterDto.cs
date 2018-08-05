using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;
using TrackingSystem.Tracking.Obd;

namespace TrackingSystem.Tracking.ObdMasters.Dto
{
    [AutoMapTo(typeof(ObdMaster))]
    public class CreateObdMasterDto
    {
        public const int NumbersLimit = 50;
        public const int MaxDescriptionLength = 64 * 1024; //64KB

        [Required]
        [MaxLength(NumbersLimit)]
        public string ObdNumber { get; set; }

        [Required]
        [MaxLength(NumbersLimit)]
        public string SimImeiNumber { get; set; }

        [Required]
        [MaxLength(NumbersLimit)]
        public string SimNumber { get; set; }

        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        public string Type { get; set; }
        [Required]
        public string Protocol { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
