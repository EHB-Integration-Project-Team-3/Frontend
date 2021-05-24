﻿using Integration_Project.Models;
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

        public IActionResult Detail() {
            var InternalUser = new InternalUser {
                EmailAddress = "test@test.test",
                FirstName = "jos",
                LastName = "joske",
            };
            return View("details", InternalUser);
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
            return View();
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
