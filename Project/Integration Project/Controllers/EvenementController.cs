using Integration_Project.Models;
using Integration_Project.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Controllers
{
    public class EvenementController : Controller
    {
        // route -> localhost/evenement/index
        public IActionResult Index()
        {
            return View();
        }

        //route -> localhost/evenement/overview
        public IActionResult Overview()
        {
            List<Event> model = new List<Event>();
            EventOverviewViewModel viewModel = new EventOverviewViewModel
            {
                Events = model,
                user = new Areas.Identity.Data.User { Email = "blablabla@blabla.blabla" }
            };
            return View(viewModel);
        }
    }
}