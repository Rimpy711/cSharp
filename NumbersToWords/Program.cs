using System;
using System.IO;
using System.Numerics;

namespace NumbersToWords
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter any Big Integer number");
            string userInput = Console.ReadLine();
            BigInteger bi = BigInteger.Parse(userInput);
            Console.WriteLine(ToWords(bi));    
           
        }
        public static string[] ReadFromFile(string path)
        {
            string[] names = File.ReadAllLines(path);

            return names;
        }

        static string ToWords(BigInteger number)
        {
            string[] partsByThree = number.ToString("N0").Split(",");
            string res = string.Empty;

            for (int i = 0; i < partsByThree.Length; i++)
            {
                if (partsByThree[i] != "000")
                {
                    res += !string.IsNullOrEmpty(res) ? " " : "";
                    res += PartToWords(partsByThree[i]);
                    res += " " + LargeNumberToWord(partsByThree.Length - i - 1);
                }
            }

            return res;
        }



         public static string LargeNumberToWord(int value)
         {
                string[] largeMap = ReadFromFile("Source/LargeNumbers.txt");
                return largeMap[value];
         }
            
          public static string PartToWords(string part)
          {
                part = part.PadLeft(3, '0');

                string[] unitsMap = ReadFromFile("Source/unitsMap.txt");
                string[] tensMap = ReadFromFile("Source/tensMap.txt");
                int index;
                string result = string.Empty;

                // transform hundreds
                if (part[0] != '0')
                {
                    index = Convert.ToInt32(part[0].ToString());
                    result += unitsMap[index] + " hundred";
                }

                // transform teens
                string tens = string.Empty;
                if (part[1] == '1')
                {
                    index = Convert.ToInt32(part[1].ToString() + part[2].ToString());
                    tens = unitsMap[index];

                    result += string.IsNullOrEmpty(result) ? "" : " and ";
                    result += tens;

                    return result;
                }
                else if (part[1] != '0')
                {
                    index = Convert.ToInt32(part[1].ToString());
                    tens = tensMap[index];
                }

                string oneDigit = string.Empty;

                if (part[2] != '0')
                {
                    index = Convert.ToInt32(part[2].ToString());
                    oneDigit = unitsMap[index];
                }
                result += !string.IsNullOrEmpty(result)
                          && !string.IsNullOrEmpty(tens) ? " and " : "";
                result += tens;

                result += !string.IsNullOrEmpty(result)
                            && string.IsNullOrEmpty(tens)
                            && !string.IsNullOrEmpty(oneDigit) ? " and " : "";

                result += !string.IsNullOrEmpty(tens)
                           && !string.IsNullOrEmpty(oneDigit) ? "-" : "";
                result += oneDigit;

                return result;
            }
        }
    }
