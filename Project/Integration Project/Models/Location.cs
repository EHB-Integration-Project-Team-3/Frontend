using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Integration_Project.Models
{
    [Serializable]
    public class Location
    {
        [Key]
        [XmlElement("uuid")]
        public Guid Uuid { get; set; }

        [XmlElement("streetName")]
        public string StreetName { get; set; }

        [XmlElement("number")]
        public string Number { get; set; }

        [XmlElement("bus")]
        public string Bus { get; set; }

        [XmlElement("city")]
        public string City { get; set; }

        [XmlElement("postalCode")]
        public string PostalCode { get; set; }

        public override string ToString()
        {
            return $"{StreetName}%{Number}%{Bus}%{City}%{PostalCode}";
        }

        public static Location FromRabbitMQ(string locationString)
        {
            try
            {
                var locationArray = locationString.Split("%");

                if (locationArray.Length == 5)
                {
                    return new Location
                    {
                        StreetName = locationArray[0],
                        Number = locationArray[1],
                        Bus = locationArray[2],
                        City = locationArray[3],
                        PostalCode = locationArray[4]
                    };
                }
                else
                {
                    return new Location
                    {
                        StreetName = locationArray[0],
                        Number = locationArray[1],
                        Bus = "0",
                        City = locationArray[2],
                        PostalCode = locationArray[3]
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return default;
            }
        }
    }
}