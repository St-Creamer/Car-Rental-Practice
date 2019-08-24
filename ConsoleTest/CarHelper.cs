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
        public void AddCar(Car car)
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

            var cars = new List<Car>();
            cars.Add(car);

            if (File.Exists(@"c:\Users\RIP\Desktop\c# console\ConsoleTest\ConsoleTest\Cars.json"))
            {
                string carlist = File.ReadAllText(@"c:\Users\RIP\Desktop\c# console\ConsoleTest\ConsoleTest\Cars.json");
                var retrievedlist = JsonConvert.DeserializeObject<List<Car>>(carlist);
                retrievedlist.Add(car);
                string json = JsonConvert.SerializeObject(retrievedlist);
                using (StreamWriter sw = File.AppendText(@"c:\Users\RIP\Desktop\c# console\ConsoleTest\ConsoleTest\Cars.json"))
                {
                    sw.WriteLine(json);
                }
            }
            else
            {
                string json = JsonConvert.SerializeObject(cars);
                using (StreamWriter sw = File.AppendText(@"c:\Users\RIP\Desktop\c# console\ConsoleTest\ConsoleTest\Cars.json"))
                {
                    sw.WriteLine(json);
                }
            }
        }
    }
}
