using Integration_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.ViewModels
{
    public class EventdetailViewModel
    {
        public Event Event { get; set; }
        public List<InternalUser> Users { get; set; }
    }
}
