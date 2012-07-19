using System.Collections.Generic;
using System.Web.Mvc;
using Module.Models;

namespace Module.Controllers
{
    public class ThingsController : Controller
    {
        public ActionResult Index()
        {
            return View(new []
                {
                    new Thing() { Name = "Thing 1" }
                });
        }
    }
}
