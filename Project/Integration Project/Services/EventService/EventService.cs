using Integration_Project.Areas.Identity.Data;
using Integration_Project.Models;
using Integration_Project.Services.EventService.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Services.EventService {
    public class EventService : IEventService {
        public bool Add(Event Event) {
            using (var context = new Integration_ProjectContext()) {
                try {
                    context.Add(Event);
                    context.SaveChanges();
                    return true;
                } catch (Exception ex) {
                    Console.WriteLine(ex);
                    return false;
                }
            }
        }
        public bool Delete(int Id) => throw new NotImplementedException();
        public bool Update(Event Event) => throw new NotImplementedException();
        Event IBaseService<Event>.Get(int Id) => throw new NotImplementedException();
        List<Event> IBaseService<Event>.GetAll() {
            using (var context = new Integration_ProjectContext()) {
                try {
                    return context.Events
                        .Include(e => e.Location)
                        .ToList();
                } catch (Exception ex) {
                    Console.WriteLine(ex);
                    return null;
                }
            }
        }
        List<Event> IBaseService<Event>.GetAllForUser(Guid UserId) => throw new NotImplementedException();
    }
}
