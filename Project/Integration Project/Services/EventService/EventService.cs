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
        public bool Delete(Guid Uuid) {
            using (var context = new Integration_ProjectContext()) {
                try {
                    context.Remove(context.Events.Where(p => p.Uuid == Uuid).FirstOrDefault());
                    context.SaveChanges();
                    return true;
                } catch (Exception ex) {
                    Console.WriteLine(ex);
                    return false;
                }
            }
        }
        public bool Update(Event Event) {
            using (var context = new Integration_ProjectContext()) {
                try {
                    var foundEvent = context.Events.Where(p => p.Uuid == Event.Uuid).FirstOrDefault();
                    if (foundEvent != null)
                        context.Update(Event);
                    context.SaveChanges();
                    return true;
                } catch (Exception ex) {
                    Console.WriteLine(ex);
                    return false;
                }
            }
        }
        Event IBaseService<Event>.Get(Guid Id) {

        }
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
        List<Event> IEventService.GetAllForUser(Guid Id) => throw new NotImplementedException();
            /*{
            using (var context = new Integration_ProjectContext())
            {
                try
                {
                    return context.Events
                        .Include(e => e.Location)
                        .Where(e => );
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }
            }
        }*/
    }
}
