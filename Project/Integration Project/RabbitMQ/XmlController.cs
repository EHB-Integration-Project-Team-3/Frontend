using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Integration_Project.Models;

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
            string _byteOrderMarkUtf8 = Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble());
            if (xml.StartsWith(_byteOrderMarkUtf8))
                xml = xml.Remove(0, _byteOrderMarkUtf8.Length);

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StringReader reader = new StringReader(xml);
            return (T)serializer.Deserialize(reader);
        }
    }
}