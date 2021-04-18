using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Shapes_List;

namespace Shapes_Xml
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<Shape> ListOfShapes = new List<Shape>
           
            {
                new Circle { Color = "Red", Radius = 2.5 },
                new Rectangle { Color = "Blue", Height = 20.0, Width = 10.0 },
                new Circle { Color = "Green", Radius = 8 },
                new Circle { Color = "Purple", Radius = 12.3 },
                new Rectangle { Color = "Blue", Height = 45.0, Width = 18.0 }
            };

            ToXml(ListOfShapes, "abc.xml");

            List<Shape> loadedShapesXml = FromXml<List<Shape>>("listOfShapes.xml");

            Console.WriteLine("Loading shapes from XML:\n");

            foreach (var item in loadedShapesXml)
            {
                Console.WriteLine($"{item.Name} is {item.Color} and has an area of {item.Area}");
            }

            Console.WriteLine("\nHave a nice day!");
        }
        public static void ToXml<T>(T obj, string path)
        {
            using (StringWriter sw = new StringWriter(new StringBuilder()))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(sw, obj);
                File.WriteAllText(path, sw.ToString());
            }
        }

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

