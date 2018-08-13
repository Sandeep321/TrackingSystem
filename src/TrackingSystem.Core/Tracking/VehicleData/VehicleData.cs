using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackingSystem.Tracking.Obd
{
    [Table("VehicleData")]
    public class VehicleData : FullAuditedEntity<int>, IMayHaveTenant, IPassivable, ICreationAudited
    {
        public const int NumbersLimit = 50;
        public const int MaxDescriptionLength = 64 * 1024; //64KB

        [Required]
        [MaxLength(NumbersLimit)]
        public string ObdNumber { get; set; }

        [Required]
        [MaxLength(NumbersLimit)]
        public string ObdSimImeiNumber { get; set; }

        [Required]
        [MaxLength(NumbersLimit)]
        public string VehicleNumber { get; set; }

        [Required]
        [MaxLength(NumbersLimit)]
        public string VehicleEngineNumber { get; set; }

        public string EngineStatus { get; set; }
        public string Altitude { get; set; }
        public string Angle { get; set; }
        public string Ignition { get; set; }
        public string Odometer { get; set; }
        public string Plate { get; set; }
        public string Position { get; set; }
        public string ACStatus { get; set; }
        public string Accelerator { get; set; }
        public string FuelStatus { get; set; }
        public string AlarmStatus { get; set; }
        public string MainBattrey { get; set; }
        public string Temprature { get; set; }
        public string Speed { get; set; }
        public string Rpm { get; set; }
        public string Load { get; set; }
        public string FuelLevel { get; set; }
        public string RunTime { get; set; }
        public int? TenantId { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public VehicleData()
        {
            CreationTime = DateTime.Now;
            LastModificationTime = DateTime.Now;
            IsActive = true;
            TenantId = null;
        }

        protected VehicleData(int? tenantId)
            : this()
        {
            TenantId = tenantId;
        }
    }
}