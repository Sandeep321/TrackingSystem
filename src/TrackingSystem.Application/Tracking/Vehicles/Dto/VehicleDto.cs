using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;
using TrackingSystem.Tracking.Obd;
using static TrackingSystem.Tracking.Obd.Vehicle;

namespace TrackingSystem.Tracking.Tasks.Dto
{
    [AutoMapFrom(typeof(Vehicle))]
    public class VehicleDto : EntityDto<int>
    {
        public const int NumbersLimit = 50;
        public const int MaxDescriptionLength = 64 * 1024; //64KB

        [Required]
        [MaxLength(NumbersLimit)]
        public string VehicleNumber { get; set; }

        [Required]
        [MaxLength(NumbersLimit)]
        public string Model { get; set; }

        [Required]
        [MaxLength(NumbersLimit)]
        public string EngineNumber { get; set; }

        [Required]
        [MaxLength(NumbersLimit)]
        public string ChassisNumber { get; set; }

        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Company { get; set; }

        [Required]
        [MaxLength(NumbersLimit)]
        public string Color { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }
        public DateTime LastRepairedOn { get; set; }
        public DateTime LastConnectedOn { get; set; }

        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        public string Type { get; set; }
        public int? TenantId { get; set; }
        public bool IsActive { get; set; }
    }   
}
