using Microsoft.AspNetCore.Antiforgery;
using TrackingSystem.Controllers;

namespace TrackingSystem.Web.Host.Controllers
{
    public class AntiForgeryController : TrackingSystemControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
