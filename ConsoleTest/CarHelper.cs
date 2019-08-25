using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleTest
{
    class CarHelper
    {
        public static List<Car> RetrieveCars()
        {
            var cars = new List<Car>();
            string json = File.ReadAllText(@"c:\Users\RIP\Desktop\c# console\ConsoleTest\ConsoleTest\Cars.json");
            var retrievedlist = JsonConvert.DeserializeObject<List<Car>>(json);
            return retrievedlist;
        }
        public static void SendListToFile(List<Car> cars)
        {
            if (File.Exists(@"c:\Users\RIP\Desktop\c# console\ConsoleTest\ConsoleTest\Cars.json"))
            {
                
                
                string json = JsonConvert.SerializeObject(cars);
                using (StreamWriter sw = File.AppendText(@"c:\Users\RIP\Desktop\c# console\ConsoleTest\ConsoleTest\Cars.json"))
                {
                    sw.WriteLine(json);
                }
            }
            else
            {
                string json = JsonConvert.SerializeObject(cars);
                using (StreamWriter sw = File.CreateText(@"c:\Users\RIP\Desktop\c# console\ConsoleTest\ConsoleTest\Cars.json"))
                {
                    sw.WriteLine(json);
                }
            }
        }

        public static void AddCar(Car car)
        {
            Console.WriteLine("Enter Car Id");
            car.Id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Car Brand");
            car.brand = Console.ReadLine();

            Console.WriteLine("Enter Car Colour");
            car.colour = Console.ReadLine();

            Console.WriteLine("Enter Car Milage Or \"n\" if not needed");

            string x = Console.ReadLine();
            if (!Regex.IsMatch(x, @"^[a-zA-Z]+$"))
            {
                car.milage = int.Parse(x);
            }

            if (!File.Exists(@"c:\Users\RIP\Desktop\c# console\ConsoleTest\ConsoleTest\Cars.json"))
            {
                File.Create(@"c:\Users\RIP\Desktop\c# console\ConsoleTest\ConsoleTest\Cars.json");
               
            }

            var cars = new List<Car>();
            cars = CarHelper.RetrieveCars();

            cars.Add(car);

            CarHelper.SendListToFile(cars);

        }
    }
}
