using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using TrackingSystem.Authorization.Roles;
using TrackingSystem.Authorization.Users;
using TrackingSystem.MultiTenancy;
using TrackingSystem.Tracking.Obd;
using TrackingSystem.Tracking;
using Abp.Authorization.Roles;

namespace TrackingSystem.EntityFrameworkCore
{
    public class TrackingSystemDbContext : AbpZeroDbContext<Tenant, Role, User, TrackingSystemDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<ObdMaster> ObdMaster { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public TrackingSystemDbContext(DbContextOptions<TrackingSystemDbContext> options)
            : base(options)
        {
        }
    }
}
