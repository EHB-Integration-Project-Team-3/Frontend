using Integration_Project.Models;
using Integration_Project.Services.EventService.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Controllers {
    public class EventController : Controller {

        private readonly IEventService _eventService;
        public EventController(IEventService eventService) {
            _eventService = eventService;
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult Overview() {
            // overview van events in DB
            return View();
        }

        public IActionResult Edit() {
            return View();
        }

        public IActionResult Create() {
            return View();
        }


    }
}
