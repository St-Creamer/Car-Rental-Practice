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

        //gets the list of cars from the json file
        public static List<Car> RetrieveCars()
        {
            
            string json = File.ReadAllText(@"c:\Users\RIP\Desktop\c# console\ConsoleTest\ConsoleTest\Cars.json");
            if(json == "" || json == "[]")
            {
                var cars = new List<Car>();
                return cars;
            }
            else
            {
                var retrievedlist = JsonConvert.DeserializeObject<List<Car>>(json);
                return retrievedlist;
            }
        }

        //sends the list of cars to the json fole
        public static void SendListToFile(List<Car> cars)
        {
            string json = JsonConvert.SerializeObject(cars);
            using (StreamWriter sw = File.CreateText(Program.appPath))
            {
                sw.WriteLine(json);
            }
        }

        //adds a car to the json file
        public static void AddCar(Car car)
        {
            Console.WriteLine("Enter Car Id");
            car.Id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Car Brand");
            car.brand = Console.ReadLine();

            Console.WriteLine("Enter Car Colour");
            car.colour = Console.ReadLine();

            Console.WriteLine("Enter Car Milage");
            car.milage = int.Parse(Console.ReadLine());

            if (!File.Exists(Program.appPath))
                File.Create(Program.appPath);

            var cars = CarHelper.RetrieveCars();
            cars.Add(car);
            CarHelper.SendListToFile(cars);

        }
    }
}
