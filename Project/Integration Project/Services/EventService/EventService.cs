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

        public Event Add(Event Event) {
            using (var context = new Integration_ProjectContext()) {
                try {
                    var ev = context.Add(Event);
                    context.SaveChanges();
                    return ev.Entity;
                } catch (Exception ex) {
                    Console.WriteLine(ex);
                    return null;
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

        public bool Delete(int Id) {
            using (var context = new Integration_ProjectContext()) {
                try {
                    var ev = context.Events.Where(p => p.Id == Id).FirstOrDefault();
                    context.Events.Remove(ev);
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
                    var ev = context.Events
                        .Where(e => e.Id == Event.Id)
                        .Include(e => e.Location)
                        .FirstOrDefault();
                    if (ev != null) {
                        ev.Description = Event.Description;
                        ev.End = Event.End;
                        ev.Start = Event.Start;
                        ev.Location = Event.Location;
                        ev.OrganiserId = Event.OrganiserId;
                        ev.Uuid = Event.Uuid;
                        ev.Title = Event.Title;
                        ev.LocationRabbit = Event.LocationRabbit;
                        ev.EntityVersion = Event.EntityVersion;
                    }
                    context.Update(ev);
                    context.SaveChanges();
                    return true;
                } catch (Exception ex) {
                    Console.WriteLine(ex);
                    return false;
                }
            }
        }


        public Event Get(int Id) {
            using (var context = new Integration_ProjectContext()) {
                try {
                    return context.Events
                        .Where(e => e.Id == Id)
                        .Include(e => e.Location)
                        .FirstOrDefault();

                } catch (Exception ex) {
                    Console.WriteLine(ex);
                    return null;
                }
            }
        }

        public Event Get(Guid Id) {
            using (var context = new Integration_ProjectContext()) {
                try {
                    return context.Events
                        .Where(e => e.Uuid == Id)
                        .Include(e => e.Location)
                        .FirstOrDefault();

                } catch (Exception ex) {
                    Console.WriteLine(ex);
                    return null;
                }
            }
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
        List<Event> IBaseService<Event>.GetAllForUser(Guid UserId) => throw new NotImplementedException();
        bool IBaseService<Event>.Add(Event t) => throw new NotImplementedException();
    }
}
