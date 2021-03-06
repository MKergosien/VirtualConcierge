﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VirtualConcierge.Models;

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

        public async Task<ActionResult> Town(string searchTerm)
        {
            if (searchTerm == null)
            {
                searchTerm = string.Empty;
            }
            YelpSharp.Options options = new YelpSharp.Options();
            options.ConsumerKey = "2rvSF2zu13f3PCFSuoPOnQ";
            options.ConsumerSecret = "_KEsaSHpFHWb5JJQAFYAM4P666U";
            options.AccessToken = "yzoEJmwYV8-HXhjKBAuWqxKVNDWqXk2f";
            options.AccessTokenSecret = "Hqw-gj-CFm2e6z1qkZ5d6NDcHuE";

            YelpSharp.Yelp yelp = new YelpSharp.Yelp(options);
            YelpSharp.Data.Options.SearchOptions searchOptions = new YelpSharp.Data.Options.SearchOptions();

            YelpSharp.Data.Options.GeneralOptions generalOptions = new YelpSharp.Data.Options.GeneralOptions();
            generalOptions.term = searchTerm;
            generalOptions.limit = 20; //TODO: Change limit later or add offset(paing) 
            generalOptions.sort = 1; //TODO: look at other sort options later
            generalOptions.category_filter = "food,restaurants";
            searchOptions.GeneralOptions = generalOptions;

            YelpSharp.Data.Options.LocationOptions locationOptions = new YelpSharp.Data.Options.LocationOptions();
            locationOptions.location = "2635 Goose Creek Bypass Franklin Tn 37064";
            searchOptions.LocationOptions = locationOptions;

            var searchResult = await yelp.Search(searchOptions);
            return View(searchResult);
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
            List<Review> result = new List<Review>();
            using (var ctx = new ReviewContext())
            {
                result = ctx.Reviews.OrderByDescending(x => x.Date).ToList();
            }
            return View(result);
        }

        [HttpPost]
        public ActionResult Guestbook(Review newReview)
        {
            if (string.IsNullOrEmpty(newReview.FirstName))
                ModelState.AddModelError("FirstName", "First name is required.");
            if (string.IsNullOrEmpty(newReview.LastName))
                ModelState.AddModelError("LastName", "Last name is required.");
            if (string.IsNullOrEmpty(newReview.Location))
                ModelState.AddModelError("Location", "Hometown is required.");
            if (string.IsNullOrEmpty(newReview.Note))
                ModelState.AddModelError("Note", "A review is required.");

            List<Review> result = new List<Review>();
            using (var ctx = new ReviewContext())
            {
                if (ModelState.IsValid)
                {
                    newReview.Date = DateTime.Now;

                    ctx.Reviews.Add(newReview);
                    if (ctx.SaveChanges() > 0)
                        ModelState.Clear();
                }
                result = ctx.Reviews.OrderByDescending(x => x.Date).ToList();
            }

            return View(result);
        }

    }
}