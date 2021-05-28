using Integration_Project.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.ViewComponents {
    public class AuthViewComponent : ViewComponent {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = HttpHelper.CheckLoggedUser();
            if (user != null)
                return View(user);
            else
                return View("_LoginPartial");
        }
    }
}
