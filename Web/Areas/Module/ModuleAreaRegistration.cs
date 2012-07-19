using System.Web.Mvc;

namespace Web.Areas.Module
{
    public class ModuleAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Module";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Module_default",
                "Module/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
