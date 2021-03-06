using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Controllers
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

        [HttpGet("/stylist/{id}")]
        public ActionResult ViewStylist(int id)
        {
            return View(Stylist.Find(id));
        }

        [HttpGet("/client/update/{id}")]
        public ActionResult UpdateClient(int id)
        {
            return View(Client.Find(id));
        }


        [HttpGet("/Client/{id}")]
        public ActionResult ViewClient(int id)
        {
            return View(Client.Find(id));
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

        [HttpPost("/client/doupdate/{clientId}")]
        public ActionResult DoUpdateClient(int clientId)
        {
            string name = Request.Form["name"];
            string phone = Request.Form["phone"];
            string address = Request.Form["address"];
            string notes = Request.Form["notes"];
            Client updateClient = new Client(name, phone, address, notes);
            updateClient.SetId(clientId);

            updateClient.Update();

            return Redirect("/stylist/" + Client.Find(clientId).GetStylistId());
        }

        [HttpGet("/Client/remove/{id}")]
        public ActionResult RemoveClient(int id)
        {
            Client removeClient = Client.Find(id);
            removeClient.Delete();
            return Redirect("/stylist/" + removeClient.GetStylistId());
        }
    }
}
