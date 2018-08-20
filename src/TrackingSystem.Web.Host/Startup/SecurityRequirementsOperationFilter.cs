using System.Collections.Generic;
using System.Linq;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Abp.Authorization;

namespace TrackingSystem.Web.Host.Startup
{
    public class SecurityRequirementsOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            var actionAttrs = context.ApiDescription.ActionAttributes();
#pragma warning restore CS0618 // Type or member is obsolete
            if (actionAttrs.OfType<AbpAllowAnonymousAttribute>().Any())
            {
                return;
            }

            if (operation.Parameters == null)
                operation.Parameters = new List<IParameter>();
            // Added Tenant Id in swagger header
            operation.Parameters.Add(new BodyParameter
            {
                Name = "Abp.TenantId",
                In = "header",
                // Description = "Tenant Id to work with",
                // Schema = new Schema { Type = "integer" },
                Required = false
            });

            //operation.Parameters.Add(new BodyParameter
            //{
            //    Name = "Authorization",
            //    In = "formData",
            //    //Description = "Tenant Id to work with",
            //    Schema = new Schema { Type = "string" },
            //    Required = false
            //});


            var controllerAttrs = context.ApiDescription.ControllerAttributes();
            var actionAbpAuthorizeAttrs = actionAttrs.OfType<AbpAuthorizeAttribute>();

            if (!actionAbpAuthorizeAttrs.Any() && controllerAttrs.OfType<AbpAllowAnonymousAttribute>().Any())
            {
                return;
            }

            var controllerAbpAuthorizeAttrs = controllerAttrs.OfType<AbpAuthorizeAttribute>();
            if (controllerAbpAuthorizeAttrs.Any() || actionAbpAuthorizeAttrs.Any())
            {
                operation.Responses.Add("401", new Response { Description = "Unauthorized" });

                var permissions = controllerAbpAuthorizeAttrs.Union(actionAbpAuthorizeAttrs)
                    .SelectMany(p => p.Permissions)
                    .Distinct();

                if (permissions.Any())
                {
                    operation.Responses.Add("403", new Response { Description = "Forbidden" });
                }

                operation.Security = new List<IDictionary<string, IEnumerable<string>>>
                {
                    new Dictionary<string, IEnumerable<string>>
                    {
                        { "bearerAuth", permissions }
                    }
                };
            }
        }
    }
}
