using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace TrackingSystem.Controllers
{
    public abstract class TrackingSystemControllerBase: AbpController
    {
        protected TrackingSystemControllerBase()
        {
            LocalizationSourceName = TrackingSystemConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
