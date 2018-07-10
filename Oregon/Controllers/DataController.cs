using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Oregon.Models;

namespace Oregon.Controllers
{
    public class DataController : Controller
    {
        [HttpGet("/search")]
        public ActionResult Search()
        {
            return View();
        }

        [HttpPost("/search/results")]
        public ActionResult SearchResults()
        {
            string name = Request.Form["name"];
            string zipCode = Request.Form["zipCode"];

            List<Places> results = Places.GetSome(name, zipCode);

            return View("SearchResults", results);
        }

        [HttpGet("/enter")]
        public ActionResult Enter()
        {
            return View();
        }

        [HttpPost("/enter/results")]
        public ActionResult EnterResults()
        {
            string name = Request.Form["name"];
            string address = Request.Form["address"];
            string category = Request.Form["category"];
            string opening = Request.Form["opening"];
            string closing = Request.Form["closing"];
            string zipCode = Request.Form["zipCode"];

            Places newPlace = new Places(0, name, address, category, opening, closing, zipCode);
            newPlace.Save();
            return View("EnterResults", newPlace);
        }

        [HttpGet("/all-results")]
        public ActionResult AllResults()
        {
            List<Places> allPlaces = Places.GetAll();
            return View(allPlaces);
        }
    }
}
