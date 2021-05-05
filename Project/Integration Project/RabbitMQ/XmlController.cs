using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Integration_Project.RabbitMQ
{
    public static class XmlController
    {
        public static string SerializeToXmlString<T>(T data)
        {
            MemoryStream stream = new MemoryStream();
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            XmlTextWriter writer = new XmlTextWriter(stream, Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            serializer.Serialize(writer, data);
            return Encoding.UTF8.GetString(stream.ToArray());
        }

        public static T DeserializeXmlString<T>(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StringReader reader = new StringReader(xml);
            return (T)serializer.Deserialize(reader);
        }
    }
}