//// Decompiled with JetBrains decompiler
//// Type: Abp.Authorization.Users.AbpUserBase
//// Assembly: Abp.Zero.Common, Version=3.7.2.0, Culture=neutral, PublicKeyToken=null
//// MVID: 85370BCE-F69E-4BB2-BDDB-E96C4A71AC25
//// Assembly location: C:\Users\TRIPATHI\.nuget\packages\abp.zero.common\3.7.2\lib\netstandard2.0\Abp.Zero.Common.dll

//using Abp.Configuration;
//using Abp.Domain.Entities;
//using Abp.Domain.Entities.Auditing;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace Abp.Authorization.Users
//{
//    /// <summary>Base class for user.</summary>
//    [Table("Vehicles")]
//    public abstract class VehicleBase : FullAuditedEntity<long>, IMayHaveTenant, IPassivable
//    {
//        /// <summary>
//        /// Maximum length of the <see cref="P:Abp.Authorization.Users.AbpUserBase.UserName" /> property.
//        /// </summary>
//        public const int MaxUserNameLength = 32;
//        /// <summary>
//        /// Maximum length of the <see cref="P:Abp.Authorization.Users.AbpUserBase.EmailAddress" /> property.
//        /// </summary>
//        public const int MaxEmailAddressLength = 256;
//        /// <summary>
//        /// Maximum length of the <see cref="P:Abp.Authorization.Users.AbpUserBase.Name" /> property.
//        /// </summary>
//        public const int MaxNameLength = 32;
//        /// <summary>
//        /// Maximum length of the <see cref="P:Abp.Authorization.Users.AbpUserBase.Surname" /> property.
//        /// </summary>
//        public const int MaxSurnameLength = 32;
//        /// <summary>
//        /// Maximum length of the <see cref="P:Abp.Authorization.Users.AbpUserBase.AuthenticationSource" /> property.
//        /// </summary>
//        public const int MaxAuthenticationSourceLength = 64;
//        /// <summary>
//        /// UserName of the admin.
//        /// admin can not be deleted and UserName of the admin can not be changed.
//        /// </summary>
//        public const string AdminUserName = "admin";
//        /// <summary>
//        /// Maximum length of the <see cref="P:Abp.Authorization.Users.AbpUserBase.Password" /> property.
//        /// </summary>
//        public const int MaxPasswordLength = 128;
//        /// <summary>
//        /// Maximum length of the <see cref="P:Abp.Authorization.Users.AbpUserBase.Password" /> without hashed.
//        /// </summary>
//        public const int MaxPlainPasswordLength = 32;
//        /// <summary>
//        /// Maximum length of the <see cref="P:Abp.Authorization.Users.AbpUserBase.EmailConfirmationCode" /> property.
//        /// </summary>
//        public const int MaxEmailConfirmationCodeLength = 328;
//        /// <summary>
//        /// Maximum length of the <see cref="P:Abp.Authorization.Users.AbpUserBase.PasswordResetCode" /> property.
//        /// </summary>
//        public const int MaxPasswordResetCodeLength = 328;
//        /// <summary>
//        /// Maximum length of the <see cref="P:Abp.Authorization.Users.AbpUserBase.PhoneNumber" /> property.
//        /// </summary>
//        public const int MaxPhoneNumberLength = 32;
//        /// <summary>
//        /// Maximum length of the <see cref="P:Abp.Authorization.Users.AbpUserBase.SecurityStamp" /> property.
//        /// </summary>
//        public const int MaxSecurityStampLength = 128;
//        /// <summary>
//        /// Authorization source name.
//        /// It's set to external authentication source name if created by an external source.
//        /// Default: null.
//        /// </summary>
//        [MaxLength(64)]
//        public virtual string AuthenticationSource { get; set; }
//        /// <summary>
//        /// User name.
//        /// User name must be unique for it's tenant.
//        /// </summary>
//        [Required]
//        [StringLength(32)]
//        public virtual string UserName { get; set; }
//        /// <summary>Tenant Id of this user.</summary>
//        public virtual int? TenantId { get; set; }
//        /// <summary>
//        /// Email address of the user.
//        /// Email address must be unique for it's tenant.
//        /// </summary>
//        [Required]
//        [StringLength(256)]
//        public virtual string EmailAddress { get; set; }
//        /// <summary>Name of the user.</summary>
//        [Required]
//        [StringLength(32)]
//        public virtual string Name { get; set; }
//        /// <summary>Surname of the user.</summary>
//        [Required]
//        [StringLength(32)]
//        public virtual string Surname { get; set; }
//        /// <summary>Return full name (Name Surname )</summary>
//        [NotMapped]
//        public virtual string FullName { get; }
//        /// <summary>Password of the user.</summary>
//        [Required]
//        [StringLength(128)]
//        public virtual string Password { get; set; }
//        /// <summary>Confirmation code for email.</summary>
//        [StringLength(328)]
//        public virtual string EmailConfirmationCode { get; set; }
//        /// <summary>
//        /// Reset code for password.
//        /// It's not valid if it's null.
//        /// It's for one usage and must be set to null after reset.
//        /// </summary>
//        [StringLength(328)]
//        public virtual string PasswordResetCode { get; set; }
//        /// <summary>Lockout end date.</summary>
//        public virtual DateTime? LockoutEndDateUtc { get; set; }
//        /// <summary>Gets or sets the access failed count.</summary>
//        public virtual int AccessFailedCount { get; set; }
//        /// <summary>Gets or sets the lockout enabled.</summary>
//        public virtual bool IsLockoutEnabled { get; set; }
//        /// <summary>Gets or sets the phone number.</summary>
//        [StringLength(32)]
//        public virtual string PhoneNumber { get; set; }
//        /// <summary>
//        /// Is the <see cref="P:Abp.Authorization.Users.AbpUserBase.PhoneNumber" /> confirmed.
//        /// </summary>
//        public virtual bool IsPhoneNumberConfirmed { get; set; }
//        /// <summary>Gets or sets the security stamp.</summary>
//        [StringLength(128)]
//        public virtual string SecurityStamp { get; set; }
//        /// <summary>Is two factor auth enabled.</summary>
//        public virtual bool IsTwoFactorEnabled { get; set; }
//        /// <summary>Login definitions for this user.</summary>
//        [ForeignKey("UserId")]
//        public virtual ICollection<UserLogin> Logins { get; set; }
//        /// <summary>Roles of this user.</summary>
//        [ForeignKey("UserId")]
//        public virtual ICollection<UserRole> Roles { get; set; }
//        /// <summary>Claims of this user.</summary>
//        [ForeignKey("UserId")]
//        public virtual ICollection<UserClaim> Claims { get; set; }
//        /// <summary>Permission definitions for this user.</summary>
//        [ForeignKey("UserId")]
//        public virtual ICollection<UserPermissionSetting> Permissions { get; set; }
//        /// <summary>Settings for this user.</summary>
//        [ForeignKey("UserId")]
//        public virtual ICollection<Setting> Settings { get; set; }
//        /// <summary>
//        /// Is the <see cref="P:Abp.Authorization.Users.AbpUserBase.EmailAddress" /> confirmed.
//        /// </summary>
//        public virtual bool IsEmailConfirmed { get; set; }
//        /// <summary>
//        /// Is this user active?
//        /// If as user is not active, he/she can not use the application.
//        /// </summary>
//        public virtual bool IsActive { get; set; }
//        /// <summary>The last time this user entered to the system.</summary>
//        public virtual DateTime? LastLoginTime { get; set; }
//        public virtual void SetNewPasswordResetCode();
//        public virtual void SetNewEmailConfirmationCode();
//        /// <summary>
//        /// Creates <see cref="T:Abp.UserIdentifier" /> from this User.
//        /// </summary>
//        /// <returns></returns>
//        public virtual UserIdentifier ToUserIdentifier();
//        public override string ToString();
//    }
//}
