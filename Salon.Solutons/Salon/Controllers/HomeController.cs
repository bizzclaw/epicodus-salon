using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Salon.Models;

namespace Salon.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            List<Stylist> allStylists = Stylist.GetAll();
            return View(allStylists);
        }

        [HttpGet("/stylist/add")]
        public ActionResult AddStylist()
        {
            return View();
        }
        [HttpPost("/stylist/new")]
        public ActionResult NewStylist()
        {
            string name = Request.Form["name"];
            Stylist newStylist = new Stylist(name);
            newStylist.Save();
            return Redirect("/");
        }
    }
}
