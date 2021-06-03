using Integration_Project.Models;
using Integration_Project.Models.Enums;
using Integration_Project.RabbitMQ;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integration_Project.Tests
{
    [TestClass]
    public class XmlTests
    {
        [TestMethod]
        public void SerializeSuccess()
        {
            //Arrange
            Header header = new Header()
            {
                Method = Method.CREATE
            };

            InternalUser user = new InternalUser()
            {
                Header = header,
                Uuid = Guid.Parse("edf24afa-1c52-4dfb-ba65-eacb69d58c0b"),
                EntityVersion = 1,
                LastName = "lastName",
                FirstName = "firstName",
                EmailAddress = "email@email.com",
                Role = Role.student
            };

            Event @event = new Event(header, Guid.Parse("edf24afa-1c52-4dfb-ba65-eacb69d58c0c"), 1, "title", user.Uuid, "description", DateTime.Parse("2000-01-28 13:00"), DateTime.Parse("2000-01-28 13:30"), "StreetName%Number%Bus%City%PostalCode");

            Heartbeat heartbeat = new Heartbeat()
            {
                TimeStamp = DateTime.Parse("2000-01-28 13:00")
            };

            HeaderAttendance headerAttendance = new HeaderAttendance()
            {
                Method = Method.CREATE
            };

            Attendance attendance = new Attendance(headerAttendance, Guid.Parse("edf24afa-1c52-4dfb-ba65-eacb69d58c0e"), Guid.Parse("edf24afa-1c52-4dfb-ba65-eacb69d58c0b"), Guid.Parse("edf24afa-1c52-4dfb-ba65-eacb69d58c0d"), Guid.Parse("edf24afa-1c52-4dfb-ba65-eacb69d58c0c"));

            string xmlStringUser = "<?xml version=\"1.0\"?>\r\n<user xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <header>\r\n    <method>CREATE</method>\r\n    <source>FRONTEND</source>\r\n  </header>\r\n  <uuid>edf24afa-1c52-4dfb-ba65-eacb69d58c0b</uuid>\r\n  <entityVersion>1</entityVersion>\r\n  <lastName>lastName</lastName>\r\n  <firstName>firstName</firstName>\r\n  <emailAddress>email@email.com</emailAddress>\r\n  <role>student</role>\r\n</user>";

            string xmlStringEvent = "<?xml version=\"1.0\"?>\r\n<event xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <header>\r\n    <method>CREATE</method>\r\n    <source>FRONTEND</source>\r\n  </header>\r\n  <uuid>edf24afa-1c52-4dfb-ba65-eacb69d58c0c</uuid>\r\n  <entityVersion>1</entityVersion>\r\n  <title>title</title>\r\n  <organiserId>edf24afa-1c52-4dfb-ba65-eacb69d58c0b</organiserId>\r\n  <description>description</description>\r\n  <start>2000-01-28T13:00:00</start>\r\n  <end>2000-01-28T13:30:00</end>\r\n  <location>StreetName%Number%Bus%City%PostalCode</location>\r\n</event>";

            string xmlStringHeartbeat = "<?xml version=\"1.0\"?>\r\n<heartbeat xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <header>\r\n    <status>ONLINE</status>\r\n    <source>FRONTEND</source>\r\n  </header>\r\n  <timeStamp>2000-01-28T13:00:00</timeStamp>\r\n</heartbeat>";

            string xmlStringAttendance = "<?xml version=\"1.0\"?>\r\n<attendance xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <header>\r\n    <method>CREATE</method>\r\n  </header>\r\n  <uuid>edf24afa-1c52-4dfb-ba65-eacb69d58c0e</uuid>\r\n  <creatorId>edf24afa-1c52-4dfb-ba65-eacb69d58c0b</creatorId>\r\n  <attendeeId>edf24afa-1c52-4dfb-ba65-eacb69d58c0d</attendeeId>\r\n  <eventId>edf24afa-1c52-4dfb-ba65-eacb69d58c0c</eventId>\r\n</attendance>";

            //Act
            string resultUser = XmlController.SerializeToXmlString(user);
            string resultEvent = XmlController.SerializeToXmlString(@event);
            string resultHeartbeat = XmlController.SerializeToXmlString(heartbeat);
            string resultAttendance = XmlController.SerializeToXmlString(attendance);

            //Assert
            Assert.IsTrue(resultUser == xmlStringUser);
            Assert.IsTrue(resultEvent == xmlStringEvent);
            Assert.IsTrue(resultHeartbeat == xmlStringHeartbeat);
            Assert.IsTrue(resultAttendance == xmlStringAttendance);
        }

        [TestMethod]
        public void SerializeFail_MissingElement()
        {
            //Arrange
            Header header = null;
            InternalUser user = new InternalUser()
            {
                Header = header,
                Uuid = Guid.Parse("edf24afa-1c52-4dfb-ba65-eacb69d58c0b"),
                EntityVersion = 1,
                LastName = "lastName",
                FirstName = "firstName",
                EmailAddress = "email@email.com",
                Role = Role.student
            };

            //Act
            string result = XmlController.SerializeToXmlString(user);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SerializeFail_NotEqualData()
        {
            //Arrange
            Header header = new Header()
            {
                Method = Method.CREATE
            };
            InternalUser user = new InternalUser()
            {
                Header = header,
                Uuid = Guid.Parse("edf24afa-1c52-4dfb-ba65-eacb69d58c0b"),
                EntityVersion = 1,
                LastName = "lastName",
                FirstName = "firstName",
                EmailAddress = "email@email.com",
                Role = Role.student
            };

            string xmlString = "<?xml version=\"1.0\"?>\r\n<user xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <header>\r\n    <method>CREATE</method>\r\n    <source>FRONTEND</source>\r\n  </header>\r\n  <uuid>edf24afa-1c52-4dfb-xxxx-eacb69d58c0b</uuid>\r\n  <entityVersion>1</entityVersion>\r\n  <lastName>lastName</lastName>\r\n  <firstName>firstName</firstName>\r\n  <emailAddress>email@email.com</emailAddress>\r\n  <role>student</role>\r\n</user>";

            //Act
            string result = XmlController.SerializeToXmlString(user);

            //Assert
            Assert.IsFalse(result == xmlString);
        }

        [TestMethod]
        public void DeserializeSuccess()
        {
            //Arrange
            Header header = new Header()
            {
                Method = Method.CREATE
            };

            InternalUser user = new InternalUser()
            {
                Header = header,
                Uuid = Guid.Parse("edf24afa-1c52-4dfb-ba65-eacb69d58c0b"),
                EntityVersion = 1,
                LastName = "lastName",
                FirstName = "firstName",
                EmailAddress = "email@email.com",
                Role = Role.student
            };

            Event @event = new Event(header, Guid.Parse("edf24afa-1c52-4dfb-ba65-eacb69d58c0c"), 1, "title", user.Uuid, "description", DateTime.Parse("2000-01-28 13:00"), DateTime.Parse("2000-01-28 13:30"), "StreetName%Number%Bus%City%PostalCode");

            Heartbeat heartbeat = new Heartbeat()
            {
                TimeStamp = DateTime.Parse("2000-01-28 13:00")
            };

            HeaderAttendance headerAttendance = new HeaderAttendance()
            {
                Method = Method.CREATE
            };

            Attendance attendance = new Attendance(headerAttendance, Guid.Parse("edf24afa-1c52-4dfb-ba65-eacb69d58c0e"), Guid.Parse("edf24afa-1c52-4dfb-ba65-eacb69d58c0b"), Guid.Parse("edf24afa-1c52-4dfb-ba65-eacb69d58c0d"), Guid.Parse("edf24afa-1c52-4dfb-ba65-eacb69d58c0c"));

            string xmlStringUser = "<?xml version=\"1.0\"?>\r\n<user xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <header>\r\n    <method>CREATE</method>\r\n    <source>FRONTEND</source>\r\n  </header>\r\n  <uuid>edf24afa-1c52-4dfb-ba65-eacb69d58c0b</uuid>\r\n  <entityVersion>1</entityVersion>\r\n  <lastName>lastName</lastName>\r\n  <firstName>firstName</firstName>\r\n  <emailAddress>email@email.com</emailAddress>\r\n  <role>student</role>\r\n</user>";

            string xmlStringEvent = "<?xml version=\"1.0\"?>\r\n<event xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <header>\r\n    <method>CREATE</method>\r\n    <source>FRONTEND</source>\r\n  </header>\r\n  <uuid>edf24afa-1c52-4dfb-ba65-eacb69d58c0c</uuid>\r\n  <entityVersion>1</entityVersion>\r\n  <title>title</title>\r\n  <organiserId>edf24afa-1c52-4dfb-ba65-eacb69d58c0b</organiserId>\r\n  <description>description</description>\r\n  <start>2000-01-28T13:00:00</start>\r\n  <end>2000-01-28T13:30:00</end>\r\n  <location>StreetName%Number%Bus%City%PostalCode</location>\r\n</event>";

            string xmlStringHeartbeat = "<?xml version=\"1.0\"?>\r\n<heartbeat xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <header>\r\n    <status>ONLINE</status>\r\n    <source>FRONTEND</source>\r\n  </header>\r\n  <timeStamp>2000-01-28T13:00:00</timeStamp>\r\n</heartbeat>";

            string xmlStringAttendance = "<?xml version=\"1.0\"?>\r\n<attendance xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <header>\r\n    <method>CREATE</method>\r\n  </header>\r\n  <uuid>edf24afa-1c52-4dfb-ba65-eacb69d58c0e</uuid>\r\n  <creatorId>edf24afa-1c52-4dfb-ba65-eacb69d58c0b</creatorId>\r\n  <attendeeId>edf24afa-1c52-4dfb-ba65-eacb69d58c0d</attendeeId>\r\n  <eventId>edf24afa-1c52-4dfb-ba65-eacb69d58c0c</eventId>\r\n</attendance>";

            //Act
            InternalUser resultUser = XmlController.DeserializeXmlString<InternalUser>(xmlStringUser);
            Event resultEvent = XmlController.DeserializeXmlString<Event>(xmlStringEvent);
            Heartbeat resultHeartbeat = XmlController.DeserializeXmlString<Heartbeat>(xmlStringHeartbeat);
            Attendance resultAttendance = XmlController.DeserializeXmlString<Attendance>(xmlStringAttendance);

            //Assert
            Assert.IsTrue(resultUser.EmailAddress == user.EmailAddress);
            Assert.IsTrue(resultUser.EntityVersion == user.EntityVersion);
            Assert.IsTrue(resultUser.FirstName == user.FirstName);
            Assert.IsTrue(resultUser.LastName == user.LastName);
            Assert.IsTrue(resultUser.Role == user.Role);
            Assert.IsTrue(resultUser.Uuid == user.Uuid);
            Assert.IsTrue(resultUser.Header.Method == user.Header.Method);
            Assert.IsTrue(resultUser.Header.Source == user.Header.Source);

            Assert.IsTrue(resultEvent.Header.Method == @event.Header.Method);
            Assert.IsTrue(resultEvent.Header.Source == @event.Header.Source);
            Assert.IsTrue(resultEvent.Uuid == @event.Uuid);
            Assert.IsTrue(resultEvent.EntityVersion == @event.EntityVersion);
            Assert.IsTrue(resultEvent.Title == @event.Title);
            Assert.IsTrue(resultEvent.OrganiserId == @event.OrganiserId);
            Assert.IsTrue(resultEvent.Description == @event.Description);
            Assert.IsTrue(resultEvent.Start == @event.Start);
            Assert.IsTrue(resultEvent.End == @event.End);
            Assert.IsTrue(resultEvent.LocationRabbit == @event.LocationRabbit);

            Assert.IsTrue(resultHeartbeat.HeaderHeartbeat.Source == heartbeat.HeaderHeartbeat.Source);
            Assert.IsTrue(resultHeartbeat.HeaderHeartbeat.Status == heartbeat.HeaderHeartbeat.Status);
            Assert.IsTrue(resultHeartbeat.TimeStamp == heartbeat.TimeStamp);

            Assert.IsTrue(resultAttendance.Header.Method == attendance.Header.Method);
            Assert.IsTrue(resultAttendance.Uuid == attendance.Uuid);
            Assert.IsTrue(resultAttendance.CreatorId == attendance.CreatorId);
            Assert.IsTrue(resultAttendance.AttendeeId == attendance.AttendeeId);
            Assert.IsTrue(resultAttendance.EventId == attendance.EventId);
        }

        [TestMethod]
        public void DeserializeFail_MissingElement()
        {
            //Arrange
            Header header = null;
            InternalUser user = new InternalUser()
            {
                Header = header,
                Uuid = Guid.Parse("edf24afa-1c52-4dfb-ba65-eacb69d58c0b"),
                EntityVersion = 1,
                LastName = "lastName",
                FirstName = "firstName",
                EmailAddress = "email@email.com",
                Role = Role.student
            };

            //Act
            string result = XmlController.SerializeToXmlString(user);

            //Assert
            Assert.IsNull(result);
        }
    }
}