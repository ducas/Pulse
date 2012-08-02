using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View(new Address
            {
                Line1 = "Unit 1",
                Line2 = "12 Test Rd",
                City = "Testington",
                Region = "Testville",
                PostalCode = "TST123",
                Country = "Testonia"
            });
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult OrgChart()
        {
            return View();
        }
    }
}
