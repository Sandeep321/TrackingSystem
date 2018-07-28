using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TrackingSystem.Authorization;

namespace TrackingSystem
{
    [DependsOn(
        typeof(TrackingSystemCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class TrackingSystemApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<TrackingSystemAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(TrackingSystemApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
