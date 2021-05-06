using Integration_Project.Models;
using Integration_Project.Services.EventService.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RabbitMQ;
using Integration_Project.RabbitMQ;

namespace Integration_Project.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
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
            // handle ev save
            //if (_eventService.Add(Ev))
            //{
            Ev.Header = new Header();
            Ev.Header.Method = Method.CREATE;
            Ev.Header.Source = Source.FRONTEND;
            Ev.Uuid = Guid.NewGuid();
            Ev.LocationRabbit = Ev.Location.ToString();
            Rabbit.Send<Event>(Ev, Constants.EventX);
            return RedirectToAction("Overview", "Event");
            //}
            //else
            //    return null;
        }
    }
}