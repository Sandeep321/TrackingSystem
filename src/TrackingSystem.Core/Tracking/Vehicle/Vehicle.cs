using Abp.Authorization.Users;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackingSystem.Tracking.Obd
{
    [Table("Vehicles")]
    public class Vehicle : FullAuditedEntity<int>, IMayHaveTenant, IPassivable, ICreationAudited
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

        [Required]
        public string Type { get; set; }
        public int? TenantId { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public Vehicle()
        {
            CreationTime = DateTime.Now;
            LastModificationTime = DateTime.Now;
            Type = null;
            IsActive = true;
            TenantId = null;
        }

        protected Vehicle(int? tenantId)
            : this()
        {
            TenantId = tenantId;
        }
        // TODO Can add other Odb Types
        //public enum VehicleType
        //{
        //    Default = 0,
        //    Type1 = 1,
        //    Type2 = 2
        //}        
    }
}
