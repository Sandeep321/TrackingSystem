using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using TrackingSystem.Authorization.Roles;
using TrackingSystem.Authorization.Users;
using TrackingSystem.MultiTenancy;

namespace TrackingSystem.EntityFrameworkCore
{
    public class TrackingSystemDbContext : AbpZeroDbContext<Tenant, Role, User, TrackingSystemDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public TrackingSystemDbContext(DbContextOptions<TrackingSystemDbContext> options)
            : base(options)
        {
        }
    }
}
