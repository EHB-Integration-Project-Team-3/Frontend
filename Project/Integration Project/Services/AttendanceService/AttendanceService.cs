using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Services.AttendanceService
{
    public class AttendanceService : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
