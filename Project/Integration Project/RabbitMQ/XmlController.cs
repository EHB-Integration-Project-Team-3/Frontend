using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Integration_Project.RabbitMQ
{
    public static class XmlController
    {
        private static bool XmlValidationErrorFound;

        public static string SerializeToXmlString<T>(T data)
        {
            try
            {
                MemoryStream stream = new MemoryStream();
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                XmlTextWriter writer = new XmlTextWriter(stream, null);
                writer.Formatting = Formatting.Indented;
                serializer.Serialize(writer, data);
                var xmlString = Encoding.UTF8.GetString(stream.ToArray());

                if (ValidateXml(xmlString, data.GetType()))
                    return xmlString;
                else
                    return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public static T DeserializeXmlString<T>(string xml)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                StringReader reader = new StringReader(xml);
                return (T)serializer.Deserialize(reader);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return default;
            }
        }

        public static bool ValidateXml(string xml, Object @object)
        {
            try
            {
                XmlValidationErrorFound = false;

                string[] fullObjectName = @object.ToString().Split('.');
                string xsdType = fullObjectName[^1];

                string schemaFile = $@"{Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\.."))}\Integration Project\RabbitMQ\XSD\{xsdType}.xsd";

                XmlTextReader schemaReader = new XmlTextReader(schemaFile);
                XmlSchema schema = XmlSchema.Read(schemaReader, SchemaValidationHandler);

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Schemas.Add(schema);

                xmlDoc.LoadXml(xml);
                xmlDoc.Validate(DocumentValidationHandler);

                return !XmlValidationErrorFound;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        private static void SchemaValidationHandler(object sender, ValidationEventArgs e)
        {
            Console.WriteLine(e.Message);
            XmlValidationErrorFound = true;
        }

        private static void DocumentValidationHandler(object sender, ValidationEventArgs e)
        {
            Console.WriteLine(e.Message);
            XmlValidationErrorFound = true;
        }
    }
}