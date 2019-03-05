using Newtonsoft.Json.Linq;
using StarWarsAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StarWarsAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("GetStarWars");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult GetStarWars()
        {

            HttpWebRequest WR = WebRequest.CreateHttp("https://swapi.co/api/people/");

            HttpWebResponse Response = (HttpWebResponse)WR.GetResponse();

            StreamReader data = new StreamReader(Response.GetResponseStream());

            string JsonData = data.ReadToEnd();

            JObject SWData = JObject.Parse(JsonData);

            List<StarWars> people = new List<StarWars>();
            for (int i = 0; i < SWData.Count; i++)
            {
                string name = SWData["results"][i]["name"].ToString();
                string birthyear = SWData["results"][i]["birth_year"].ToString();
                string films = SWData["results"][i]["films"].ToString(); //this won't work
                string vehicles = SWData["results"][i]["vehicles"].ToString();//this also won't work
                StarWars person = new StarWars(name, birthyear, films, vehicles);
                people.Add(person);

            }
            ViewBag.People = people;
            return View();
        }
    }
}