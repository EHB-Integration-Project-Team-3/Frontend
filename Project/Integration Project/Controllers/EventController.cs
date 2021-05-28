using Integration_Project.Models;
using Integration_Project.Services.EventService.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RabbitMQ;
using Integration_Project.RabbitMQ;
using Integration_Project.Services.MUUIDService.Interface;
using Integration_Project.Models.Enums;
using Integration_Project.Extensions;

namespace Integration_Project.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IMUUIDService _muuidService;
 
        public EventController(IEventService eventService, IMUUIDService muuidService)
        {
            _eventService = eventService;
            _muuidService = muuidService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Overview()
        {
            var Events = _eventService.GetAll();
            return View(Events);
        }

        //[UserPermission]
        public IActionResult Detail(Event Evt)
        {
            var user = HttpHelper.CheckLoggedUser();
            if (user != null /*&& user.Uuid == Evt.OrganiserId*/)
            {
                return View("Detail", Evt);
            }
            else
            {
                return Redirect("/");
            }
        }

        //[UserPermission]
        public IActionResult Edit()
        {
            return View();
        }

        //[UserPermission]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[UserPermission]
        public IActionResult CreateEvent(Event Ev)
        {
            var user = HttpHelper.CheckLoggedUser();
            // adding event to database
            Ev.Header = new Header();
            Ev.Header.Method = Method.CREATE;
            // ask new uuid to the masterUUID;
            Ev.Uuid = _muuidService.GetUUID();
            Ev.OrganiserId = user != null ? user.Uuid : new Guid("84e36290-19bc-4e48-8cb6-9d80322dcaf1"); //uuid van ingelogde user
            Ev.LocationRabbit = Ev.Location.ToString();
            Rabbit.Send<Event>(Ev, Constants.EventX);
            return RedirectToAction("Overview", "Event");
        }
    }
}