using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TrackingSystem.Configuration;

namespace TrackingSystem.Web.Host.Startup
{
    [DependsOn(
       typeof(TrackingSystemWebCoreModule))]
    public class TrackingSystemWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public TrackingSystemWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TrackingSystemWebHostModule).GetAssembly());
        }
    }
}
