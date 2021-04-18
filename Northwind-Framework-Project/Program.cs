using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

namespace Northwind_Framework_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new DbModel.northwindContext();
            var customersList = context.Customers.ToList();

            var context2 = new DbModel.northwindContext();
            var productsList = context2.Products.ToList();

            /* foreach (var item in customersList)
             {
                 Console.WriteLine($"{item.LastName} {item.FirstName} {item.JobTitle}");
             }*/
            //  Helper.Serializer.ToJson(productsList, "products.json");
            // Helper.Serializer.ToXml(productsList, "products.xml");
            // Helper.Serializer.ToBinary(productsList, "products.dat");
            List<SerializedFile>fileList = new List<SerializedFile>
            {
                new SerializedFile
                {
                    Name = "products.json",
                    Size = new FileInfo("products.json").Length
                },
                new SerializedFile
                {
                    Name = "products.xml",
                    Size = new FileInfo("products.xml").Length
                },
                new SerializedFile
                {
                    Name = "products.dat",
                    Size = new FileInfo("products.dat").Length
                },


            };

            fileList.Sort();

            Console.WriteLine("Ranked Files: \n");

            foreach (var item in fileList)
            {
                Console.WriteLine($"{item.Name} has {item.Size} bytes");
            }

            Console.WriteLine("\n*****************Assignmnet-2***********************\n");

            var cities = customersList.Select(c => c.City).Distinct().ToList();

            List<string> citiesList = cities.ToList();

            cities.Sort();

            string joined = string.Join(", ", cities.ToArray());

            Console.Write("Here is the city list: \n\n" + joined +
                "\n\nPlease enter a city: ");

            var cityEntry = Console.ReadLine();

            var customerCityList = customersList.Where(c => c.City.Equals(cityEntry));

            if (customerCityList.Count() != 1)
            {
                Console.WriteLine($"\nThere are {customerCityList.Count()} customers in {cityEntry}: \n");
            }

            else
            {
                Console.WriteLine($"\nThere is {customerCityList.Count()} customer in {cityEntry}: \n");
            }

            foreach (var item in customerCityList)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }

            Console.WriteLine("\n========================================");

            Console.WriteLine("\nHave a nice day!");



        }
    }
       public class SerializedFile : IComparable<SerializedFile>
        {
            public string Name { get; set; }
            public long Size { get; set; }

            public int CompareTo([AllowNull] SerializedFile other)
            {
                return Size.CompareTo(other.Size);
            }

        }
    }
    
