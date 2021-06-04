using Integration_Project.Models;
using Integration_Project.Services.EventService.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RabbitMQ;
using Integration_Project.RabbitMQ;
using Integration_Project.Areas.Identity.Data;
using Integration_Project.Services.UserService.Interface;
using Integration_Project.Extensions;

namespace Integration_Project.Controllers {
    public class UserController : Controller {
        private readonly IUserService _userService;

        public UserController(IUserService userService) {
            _userService = userService;
        }
        public IActionResult Index() {
            return View();
        }

        public IActionResult Overview() {
            var Events = _userService.GetAll();
            return View(Events);
        }

        //[UserPermission]
        public IActionResult Detail() {
            var user = HttpHelper.CheckLoggedUser();
            if (user != null) {
                return View("details", user);
            } else {
                return Redirect("/");
            }
        }

        [HttpPost]
        public IActionResult Validate(string Email, string Wachtwoord) {
            var user = _userService.Validate(Email, Wachtwoord);
            if (user != null) {
                HttpContext.Session.Set("User", ModelHelper<InternalUser>.ObjectToByteArray(user));
            } else {
                HttpContext.Session.Set("Error", ModelHelper<InternalUser>.ObjectToByteArray("Gelieve jouw credentials na te kijken."));
                return Redirect("/Identity/Account/Login");
            };
            return RedirectToAction("Index", "Home");
        }


        public IActionResult Logout() {
            HttpContext.Session.Remove("User");
            return RedirectToAction("Index", "Home");
        }

        //[UserPermission]
        public IActionResult Edit() {
            return View();
        }

        //[UserPermission]
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        //[UserPermission]
        public IActionResult CreateUser(User Usr) => throw new NotImplementedException();
    }
}
