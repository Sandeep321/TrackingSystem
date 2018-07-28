using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using TrackingSystem.Configuration;
using TrackingSystem.Web;

namespace TrackingSystem.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class TrackingSystemDbContextFactory : IDesignTimeDbContextFactory<TrackingSystemDbContext>
    {
        public TrackingSystemDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<TrackingSystemDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            TrackingSystemDbContextConfigurer.Configure(builder, configuration.GetConnectionString(TrackingSystemConsts.ConnectionStringName));

            return new TrackingSystemDbContext(builder.Options);
        }
    }
}
