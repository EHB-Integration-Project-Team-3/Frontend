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

namespace Integration_Project.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Overview()
        {
            var Events = _userService.GetAll();
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
        public IActionResult CreateUser(User Usr) => throw new NotImplementedException();
    }
}
