using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtherModule.Controllers
{
    public class RandomController : Controller
    {
        //
        // GET: /Random/

        public ActionResult Index()
        {
            return Json(new { Id = 1 }, JsonRequestBehavior.AllowGet);
        }

    }
}
