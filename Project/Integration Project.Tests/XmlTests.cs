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
            Header header = new()
            {
                Method = Method.CREATE
            };
            // InternalUser user = new(header, Guid.Parse("edf24afa-1c52-4dfb-ba65-eacb69d58c0b"), 1, "lastName", "firstName", "email@email.com", Role.student);

            Event @event = new(header, Guid.Parse("edf24afa-1c52-4dfb-ba65-eacb69d58c0c"), 1, "title", user.Uuid, "description", DateTime.Parse("2000-01-28 13:00"), DateTime.Parse("2000-01-28 13:30"), "StreetName%Number%Bus%City%PostalCode");

            string xmlStringUser = "<?xml version=\"1.0\"?>\r\n<user xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <header>\r\n    <method>CREATE</method>\r\n    <source>FRONTEND</source>\r\n  </header>\r\n  <uuid>edf24afa-1c52-4dfb-ba65-eacb69d58c0b</uuid>\r\n  <entityVersion>1</entityVersion>\r\n  <lastName>lastName</lastName>\r\n  <firstName>firstName</firstName>\r\n  <emailAddress>email@email.com</emailAddress>\r\n  <role>student</role>\r\n</user>";

            string xmlStringEvent = "<?xml version=\"1.0\"?>\r\n<event xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <header>\r\n    <method>CREATE</method>\r\n    <source>FRONTEND</source>\r\n  </header>\r\n  <uuid>edf24afa-1c52-4dfb-ba65-eacb69d58c0c</uuid>\r\n  <entityVersion>1</entityVersion>\r\n  <title>title</title>\r\n  <organiserId>edf24afa-1c52-4dfb-ba65-eacb69d58c0b</organiserId>\r\n  <description>description</description>\r\n  <start>2000-01-28T13:00:00</start>\r\n  <end>2000-01-28T13:30:00</end>\r\n  <location>StreetName%Number%Bus%City%PostalCode</location>\r\n</event>";

            //Act
            string resultUser = XmlController.SerializeToXmlString(user);
            string resultEvent = XmlController.SerializeToXmlString(@event);

            //Assert
            Assert.IsTrue(resultUser == xmlStringUser);
            Assert.IsTrue(resultEvent == xmlStringEvent);
        }

        [TestMethod]
        public void SerializeFail_MissingElement()
        {
            //Arrange
            Header header = null;
            InternalUser user = new(header, Guid.Parse("edf24afa-1c52-4dfb-ba65-eacb69d58c0b"), 1, "lastName", "firstName", "email@email.com", Role.student);

            //Act
            string result = XmlController.SerializeToXmlString(user);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SerializeFail_NotEqualData()
        {
            //Arrange
            Header header = new()
            {
                Method = Method.CREATE
            };
            InternalUser user = new(header, Guid.Parse("edf24afa-1c52-4dfb-ba65-eacb69d58c0b"), 1, "lastName", "firstName", "email@email.com", Role.student);

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
            Header header = new()
            {
                Method = Method.CREATE
            };
            InternalUser user = new(header, Guid.Parse("edf24afa-1c52-4dfb-ba65-eacb69d58c0b"), 1, "lastName", "firstName", "email@email.com", Role.student);

            string xmlString = "<?xml version=\"1.0\"?>\r\n<user xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <header>\r\n    <method>CREATE</method>\r\n    <source>FRONTEND</source>\r\n  </header>\r\n  <uuid>edf24afa-1c52-4dfb-ba65-eacb69d58c0b</uuid>\r\n  <entityVersion>1</entityVersion>\r\n  <lastName>lastName</lastName>\r\n  <firstName>firstName</firstName>\r\n  <emailAddress>email@email.com</emailAddress>\r\n  <role>student</role>\r\n</user>";

            //Act
            InternalUser result = XmlController.DeserializeXmlString<InternalUser>(xmlString);

            //Assert
            Assert.IsTrue(result.EmailAddress == user.EmailAddress);
            Assert.IsTrue(result.EntityVersion == user.EntityVersion);
            Assert.IsTrue(result.FirstName == user.FirstName);
            Assert.IsTrue(result.LastName == user.LastName);
            Assert.IsTrue(result.Role == user.Role);
            Assert.IsTrue(result.Uuid == user.Uuid);
            Assert.IsTrue(result.Header.Method == user.Header.Method);
            Assert.IsTrue(result.Header.Source == user.Header.Source);
        }

        [TestMethod]
        public void DeserializeFail_MissingElement()
        {
            //Arrange
            Header header = null;
            InternalUser user = new(header, Guid.Parse("edf24afa-1c52-4dfb-ba65-eacb69d58c0b"), 1, "lastName", "firstName", "email@email.com", Role.student);

            //Act
            string result = XmlController.SerializeToXmlString(user);

            //Assert
            Assert.IsNull(result);
        }
    }
}