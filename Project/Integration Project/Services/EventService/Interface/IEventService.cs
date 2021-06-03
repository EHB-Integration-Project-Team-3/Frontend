using Integration_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Services.EventService.Interface {
    public interface IEventService : IBaseService<Event> {
        public bool Delete(Guid Uuid);

        public Event Get(Guid Id);
    }
}
