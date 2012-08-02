using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;

namespace OtherModule.Controllers
{
    public class RandomController : Controller
    {
        //
        // GET: /Random/

        public ActionResult Index()
        {
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

    }
}
