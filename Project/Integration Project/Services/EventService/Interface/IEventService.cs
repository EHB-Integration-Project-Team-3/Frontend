using Integration_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Services.EventService.Interface {
    public interface IEventService : IBaseService<Event> {
        public List<Event> GetAllForUser(Guid Id)
    }
}
