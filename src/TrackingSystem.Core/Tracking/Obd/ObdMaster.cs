using Abp.Authorization.Users;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackingSystem.Tracking.Obd
{
    [Table("ObdMaster")]
    public class ObdMaster : FullAuditedEntity<int>, IMayHaveTenant, IPassivable, ICreationAudited
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

        public ObdType Type { get; set; }
        public ObdProtocol Protocol { get; set; }
        public int? TenantId { get; set; }
        public bool IsActive { get; set; }
        public ObdMaster()
        {
            CreationTime = DateTime.Now;
            LastModificationTime = DateTime.Now;
            Type = ObdType.Default;
            IsActive = true;
            Protocol = ObdProtocol.Default;
            TenantId = null;
        }

        protected ObdMaster(int? tenantId)
            : this()
        {
            TenantId = tenantId;
        }
        // TODO Can add other Odb Types
        public enum ObdType
        {
            Default = 0,
            Type1 = 1,
            Type2 = 2
        }

        // TODO Can add other Odb Protocols
        public enum ObdProtocol
        {
            Default = 0,
            Type1 = 1,
            Type2 = 2
        }
    }    
}
