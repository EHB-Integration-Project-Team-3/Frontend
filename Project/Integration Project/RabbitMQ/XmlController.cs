﻿using System;
using System.Diagnostics;
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
            try
            {
                MemoryStream stream = new MemoryStream();
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                XmlTextWriter writer = new XmlTextWriter(stream, Encoding.UTF8);
                writer.Formatting = Formatting.Indented;
                serializer.Serialize(writer, data);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return "";
            }
        }

        public static T DeserializeXmlString<T>(string xml)
        {
            try
            {
                string _byteOrderMarkUtf8 = Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble());
                if (xml.StartsWith(_byteOrderMarkUtf8))
                    xml = xml.Remove(0, _byteOrderMarkUtf8.Length);

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
    }
}