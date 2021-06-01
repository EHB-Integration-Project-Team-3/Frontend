using Integration_Project.Models;
using Integration_Project.Services.EventService.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RabbitMQ;
using Integration_Project.RabbitMQ;
using Integration_Project.Services.MUUIDService.Interface;
using Integration_Project.Models.Enums;
using Integration_Project.Extensions;

namespace Integration_Project.Controllers {
    public class EventController : Controller {
        private readonly IEventService _eventService;
        private readonly IMUUIDService _muuidService;
        private readonly IAttendanceService _attendanceService;

        public EventController(IEventService eventService, IMUUIDService muuidService, IAttendanceService attendanceService) {
            _eventService = eventService;
            _muuidService = muuidService;
            _attendanceService = attendanceService;
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult Overview() {
            var Events = _eventService.GetAll();
            foreach (var ev in Events) {
                ev.Attendees = _attendanceService.GetAllForEvent(ev.Uuid);
            }
            return View(Events == null ? new List<Event>() : Events);
        }

        public IActionResult SubscribeToEvent(Guid eventId) {
            var attendance = new Attendance {
                EventId = eventId,
                UserId = HttpHelper.CheckLoggedUser().Uuid,
            };
            if (_attendanceService.Add(attendance)) {
                Rabbit.Send<Attendance>(attendance, Constants.AttendanceX);
                return Redirect(HttpContext.Request.Headers["Referer"]);
            }
                // failed to save attendace
                return View();
        }


        public IActionResult Detail(int Id) {
            var ev = _eventService.Get(Id);

            return View("Detail", ev);
        }

        public IActionResult Edit(int id) {
            var ev = _eventService.Get(id);
            return View(ev);
        }

        [HttpPost]
        public IActionResult Update(Event ev) {
            var eventMuid = _muuidService.Get(ev.Uuid);
            if (ev.EntityVersion < eventMuid.EntityVersion) {
                // Hier moet er dan via de consumer een update worden binnen gehaald
            } else {
                ev.Header = new Header {
                    Method = Method.UPDATE
                };
                ev.EntityVersion += 1;
                Rabbit.Send<Event>(ev, Constants.EventX);

                //_eventService.Update(ev); naar de receiver verplaatst
            }
            return RedirectToAction("Edit", "Event");
        }

        //[UserPermission]
        public IActionResult Create() {
            return View();
        }

        public IActionResult Test() {
            var x = _muuidService.Get(Guid.Parse("3d597104-bfb1-11eb-b876-00155d110504"));
            _muuidService.UpdateEntityVersion(
                new Models.MUUID.Send.MUUIDSend {
                    EntityType = EntityType.Event,
                    Source = Source.FRONTEND,
                    Source_EntityId = x.Source_EntityId,
                    Uuid = x.Uuid
                }, 5);
            ;
            return View();
        }

        [HttpPost]
        //[UserPermission]
        public IActionResult CreateEvent(Event Ev) {
            var user = HttpHelper.CheckLoggedUser();

            Ev.Header = new Header {
                Method = Method.CREATE
            };
            // ask new uuid to the masterUUID;
            Ev.Uuid = _muuidService.GetUUID();
            Ev.OrganiserId = user != null ? user.Uuid : new Guid("84e36290-19bc-4e48-8cb6-9d80322dcaf1"); //uuid van ingelogde user
            Ev.LocationRabbit = Ev.Location.ToString();
            // set on rabbit que to other platforms
            Rabbit.Send<Event>(Ev, Constants.EventX);

            // create new row in MUUID
            _muuidService.InsertIntoMUUID(new Models.MUUID.Send.MUUIDSend {
                EntityType = EntityType.Event,
                Source = Source.FRONTEND,
                Source_EntityId = Ev.Id.ToString(),
                Uuid = Ev.Uuid
            });


            //Add LoggedUser to Event Attendance

            var att = new Attendance();

            att.Header = new Header {
                Method = Method.CREATE
            };

            // ask new uuid to the masterUUID;
            att.Uuid = _muuidService.GetUUID();
            att.UserId = Ev.OrganiserId;  //user != null ? user.Uuid : new Guid("84e36290-19bc-4e48-8cb6-9d80322dcaf1"); //uuid van ingelogde user
            att.EventId = Ev.Uuid;
            // set on rabbit que to other platforms
            Rabbit.Send<Attendance>(att, Constants.AttendanceX);

            // create new row in MUUID
            _muuidService.InsertIntoMUUID(new Models.MUUID.Send.MUUIDSend {
                EntityType = EntityType.Attendance,
                Source = Source.FRONTEND,
                Source_EntityId = att.Uuid.ToString(),
                Uuid = att.Uuid
            });

            return RedirectToAction("Overview", "Event");
        }
    }
}