using Integration_Project.Models;
using Integration_Project.Services.MUUIDService.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly IMUUIDService _muuidService;

        public HomeController(ILogger<HomeController> logger, IMUUIDService muuidService) {
            _logger = logger;
            _muuidService = muuidService;
        }

        public IActionResult Index() {
            var uuidFromMasterUUID = _muuidService.GetUUID();
            return View();
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
