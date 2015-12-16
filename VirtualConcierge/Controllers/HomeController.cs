using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VirtualConcierge.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {
           // ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Pets()
        {

            return View();
        }

        public ActionResult General()
        {

            return View();
        }

        public ActionResult Town()
        {

            return View();
        }

        public ActionResult Games()
        {

            return View();
        }

        public ActionResult Guestbook()
        {

            return View();
        }

    }
}