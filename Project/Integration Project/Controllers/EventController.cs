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
            // adding event to database
            Ev.Header = new Header();
            Ev.Header.Method = Method.CREATE;
            // ask new uuid to the masterUUID;
            Ev.Uuid = _muuidService.GetUUID();
            Ev.OrganiserId = new Guid("172DC55B-BD86-11EB-B876-00155D110504"); //uuid van ingelogde user
            Ev.LocationRabbit = Ev.Location.ToString();
            Rabbit.Send<Event>(Ev, Constants.EventX);
            return RedirectToAction("Overview", "Event");
        }
    }
}