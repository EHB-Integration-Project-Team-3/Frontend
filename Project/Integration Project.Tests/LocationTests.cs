using Integration_Project.Models;
using Integration_Project.Models.Enums;
using Integration_Project.RabbitMQ;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Integration_Project.Tests
{
    [TestClass]
    public class LocationTests
    {
        [TestMethod]
        public void LocationObjectToStringSuccess()
        {
            //Arrange
            Location location = new Location()
            {
                Uuid = Guid.Parse("edf24afa-1c52-4dfb-ba65-eacb69d58c0b"),
                StreetName = "streetName",
                Number = "15",
                Bus = "02",
                City = "City",
                PostalCode = "8050"
            };

            string locationString = "streetName%15%02%City%8050";

            //Act
            var locationResult = location.ToString();

            //Assert
            Assert.IsTrue(locationResult == locationString);
        }

        [TestMethod]
        public void LocationObjectToStringGoogleMapsSuccess()
        {
            //Arrange
            Location location = new Location()
            {
                Uuid = Guid.Parse("edf24afa-1c52-4dfb-ba65-eacb69d58c0b"),
                StreetName = "streetName",
                Number = "15",
                Bus = "02",
                City = "City",
                PostalCode = "8050"
            };

            string locationString = "streetName 15 02 City 8050";

            //Act
            var locationResult = location.ToStringForGoogleMaps();

            //Assert
            Assert.IsTrue(locationResult == locationString);
        }
    }
}