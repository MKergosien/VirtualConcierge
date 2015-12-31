using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
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
            BGGAPI.Client client = new BGGAPI.Client();
            //BGGAPI.Thing.Request request = new BGGAPI.Thing.Request();
            BGGAPI.Collection.Request request = new BGGAPI.Collection.Request();
            request.UserName = "gaines";
            request.Own = true;
            request.ExcludeSubType = BGGAPI.Collection.Request.Type.BoardGameExpansion;
            var result = client.GetCollection(request);
            
            return View(result);
        }
           
        public ActionResult Guestbook()
        {

            return View();
        }

    }
}