using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Shapes_List;
using Helper;

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

            Serializer.ToXml(ListOfShapes, "abc.xml");

            List<Shape> loadedShapesXml = Deserializer.FromXml<List<Shape>>("listOfShapes.xml");

            Console.WriteLine("Loading shapes from XML:\n");

            foreach (var item in loadedShapesXml)
            {
                Console.WriteLine($"{item.Name} is {item.Color} and has an area of {item.Area}");
            }

            Console.WriteLine("\nHave a nice day!");
        }
       

   }
}

