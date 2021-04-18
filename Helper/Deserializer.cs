using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Helper
{
    public class Deserializer
    {
        public static T FromXml<T>(string path)
        {
            string xmlString = File.ReadAllText(path);
            using (StringReader sr = new StringReader(xmlString))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                return (T)xmlSerializer.Deserialize(sr);
            }
        }

    }
}
