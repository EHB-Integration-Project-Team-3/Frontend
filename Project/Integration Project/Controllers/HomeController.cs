using Integration_Project.Models;
using Integration_Project.Services.EventService.Interface;
using Integration_Project.Services.MUUIDService.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Controllers {

    public class HomeViewModel {
        public List<Event> Events { get; set; }
    }
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly IMUUIDService _muuidService;
        private readonly IEventService _eventService;
        public HomeController(ILogger<HomeController> logger, IMUUIDService muuidService, IEventService eventService) {
            _logger = logger;
            _muuidService = muuidService;
            _eventService = eventService;
        }

        public IActionResult Index() {
            var model = new HomeViewModel { Events = _eventService.GetAll() };
            return View(model);
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
