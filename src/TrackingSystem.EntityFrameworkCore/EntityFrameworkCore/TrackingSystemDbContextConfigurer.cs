using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace TrackingSystem.EntityFrameworkCore
{
    public static class TrackingSystemDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<TrackingSystemDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<TrackingSystemDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
