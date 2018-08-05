using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Configuration;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Extensions;

namespace Abp.Authorization.Users
{
    /// <summary>
    /// Base class for user.
    /// </summary>
    [Table("Obd")]
    public abstract class ObdBase : FullAuditedEntity<long>, IMayHaveTenant, IPassivable
    {
        /// <summary>
        /// Tenant Id of this user.
        /// </summary>
        public virtual int? TenantId { get; set; }

        /// <summary>
        /// Authorization source name.
        /// It's set to external authentication source name if created by an external source.
        /// Default: null.
        /// </summary>
        [Required]
        public virtual string SimImeiNumber { get; set; }

        /// <summary>
        /// User name.
        /// User name must be unique for it's tenant.
        /// </summary>
        [Required]
        public virtual string ObdNumber { get; set; }

        [Required]
        public virtual string SimNumber { get; set; }

        [Required]
        public virtual string ObdType { get; set; }

        [Required]
        public virtual string ObdDescription { get; set; }
        
        /// <summary>
        /// Is this user active?
        /// If as user is not active, he/she can not use the application.
        /// </summary>
        public virtual bool IsActive { get; set; }

        protected ObdBase()
        {
            IsActive = true;            
        }
    }
}