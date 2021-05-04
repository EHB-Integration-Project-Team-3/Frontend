using Integration_Project.Areas.Identity.Data;
using Integration_Project.Data;
using Integration_Project.Models;
using Integration_Project.Services.EventService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Services.EventService {
    public class EventService : IEventService {
        public bool Add(Event Event) {
            return false;
        }

        public bool Delete(int Id) => throw new NotImplementedException();
        public bool Update(Event Event) => throw new NotImplementedException();
        Event IBaseService<Event>.Get(int Id) => throw new NotImplementedException();
        List<Event> IBaseService<Event>.GetAll() => throw new NotImplementedException();
        List<Event> IBaseService<Event>.GetAllForUser(Guid UserId) => throw new NotImplementedException();
    }
}
