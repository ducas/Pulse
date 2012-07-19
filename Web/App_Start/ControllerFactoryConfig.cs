using System.Web.Mvc;
using Web.Core;

namespace Web.App_Start
{
    public static class ControllerFactoryConfig
    {
        public static void Start()
        {
            ControllerBuilder.Current.SetControllerFactory(typeof(MyControllerFactory));
        }
    }
}