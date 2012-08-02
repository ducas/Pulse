using System.Web.Mvc;

namespace OtherModule
{
    public class OtherModuleAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "OtherModule";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "OtherModule_default",
                "OtherModule/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
