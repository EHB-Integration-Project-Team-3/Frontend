using Integration_Project.Areas.Identity.Data;
using Integration_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Models.ViewModels
{
    public class EventOverviewViewModel
    {
        public List<Event> Events { get; set; }
        public User user;
    }
}