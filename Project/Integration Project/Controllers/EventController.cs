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
using Integration_Project.ViewModels;
using Integration_Project.Services.UserService.Interface;

namespace Integration_Project.Controllers {
    public class EventController : Controller {
        private readonly IEventService _eventService;
        private readonly IMUUIDService _muuidService;
        private readonly IAttendanceService _attendanceService;
        private readonly IUserService _userService;

        public EventController(IEventService eventService, IMUUIDService muuidService, IAttendanceService attendanceService, IUserService userService) {
            _eventService = eventService;
            _muuidService = muuidService;
            _attendanceService = attendanceService;
            _userService = userService;
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

        public IActionResult SubscribeToEvent(int eventId) {
            HeaderAttendance header = new HeaderAttendance {
                Method = Method.CREATE
            };

            Event @event = _eventService.Get(eventId);

            var attendance = new Attendance {
                Header = header,
                EventId = @event.Uuid,
                CreatorId = @event.OrganiserId,
                AttendeeId = HttpHelper.CheckLoggedUser().Uuid,
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
            var users = new List<InternalUser>();
            foreach (Attendance attendance in _attendanceService.GetAllForEvent(ev.Uuid)) {
                users.Add(_userService.Get(attendance.CreatorId));
            }

            var viewmodel = new EventdetailViewModel();
            viewmodel.Event = ev;
            viewmodel.Users = users;

            return View("Detail", viewmodel);
        }

        public IActionResult Edit(int id) {
            var ev = _eventService.Get(id);
            return View(ev);
        }

        [HttpPost]
        public IActionResult Update(Event ev) {


            ev.Header = new Header {
                Method = Method.UPDATE
            };
            ev.EntityVersion += 1;
            Rabbit.Send<Event>(ev, Constants.EventX);

            //_eventService.Update(ev); naar de receiver verplaatst

            return RedirectToAction("Overview", "Event");
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
            Ev.EntityVersion = 1;
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

            att.Header = new HeaderAttendance {
                Method = Method.CREATE
            };

            // ask new uuid to the masterUUID;
            att.Uuid = _muuidService.GetUUID();
            att.CreatorId = Ev.OrganiserId;  //user != null ? user.Uuid : new Guid("84e36290-19bc-4e48-8cb6-9d80322dcaf1"); //uuid van ingelogde user
            att.EventId = Ev.Uuid;
            att.AttendeeId = Ev.OrganiserId;
            // set on rabbit que to other platforms
            Rabbit.Send<Attendance>(att, Constants.AttendanceX);
            // save on local db
            _attendanceService.Add(att);

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