using Integration_Project.Models.Evenements;
using Integration_Project.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Controllers {
    public class EvenementController : Controller {

        // route -> localhost/evenement/index
        public IActionResult Index() {
            return View();
        }

        //route -> localhost/evenement/overview
        public IActionResult Overview() {
            List<Evenement> model = new List<Evenement>();
            EventOverviewViewModel viewModel = new EventOverviewViewModel {
                Evenements = model,
                user = new Areas.Identity.Data.User { Email = "blablabla@blabla.blabla" }
            };
            return View(viewModel);
        }


        

    }
}
