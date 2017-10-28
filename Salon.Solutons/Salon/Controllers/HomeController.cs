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

        [HttpGet("/client/add/{stylistId}")]
        public ActionResult AddClient(int stylistId)
        {
            Stylist clientStylist = Stylist.Find(stylistId);
            return View(clientStylist);
        }

        [HttpGet("/Stylist/{id}")]
        public ActionResult ViewStylist(int id)
        {
            return View(Stylist.Find(id));
        }

        [HttpPost("/stylist/new")]
        public ActionResult NewStylist()
        {
            string name = Request.Form["name"];
            Stylist newStylist = new Stylist(name);
            newStylist.Save();
            return Redirect("/");
        }

        [HttpPost("/client/new/{stylistId}")]
        public ActionResult NewClient(int stylistId)
        {
            string name = Request.Form["name"];
            string phone = Request.Form["phone"];
            string address = Request.Form["address"];
            string notes = Request.Form["notes"];
            Client newClient = new Client(name, phone, address, notes);
            newClient.Save(stylistId);
            return Redirect("/stylist/" + stylistId);
        }
    }
}
