using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AseguradoraREST.ServiceReference1;

namespace AseguradoraREST.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            ServiceReference1.Service1Client sc = new Service1Client();
            sc.AddPolicie(1, "andres", "fonk", "mola");
            return View();
        }
    }
}
