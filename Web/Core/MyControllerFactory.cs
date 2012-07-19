using System;
using System.Linq;
using System.Web.Mvc;

namespace Web.Core
{
    public class MyControllerFactory : DefaultControllerFactory
    {
        protected override Type GetControllerType(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            var area = requestContext.RouteData.DataTokens["area"] as string;
            if (!string.IsNullOrEmpty(area))
            {
                var assembly = AppDomain.CurrentDomain
                    .GetAssemblies()
                    .FirstOrDefault(a => a.GetName().Name.EndsWith(area, StringComparison.InvariantCultureIgnoreCase));
                if (assembly != null)
                {
                    var controllerType = assembly.GetTypes().FirstOrDefault(t => t.Name.Equals(controllerName + "Controller", StringComparison.InvariantCultureIgnoreCase));
                    if (controllerType != null) return controllerType;
                }
            }
            return base.GetControllerType(requestContext, controllerName);
        }
    }
}