﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleTest
{
    class Program
    {
        public static string appPath = Directory.GetCurrentDirectory();
        static void Main(string[] args)
        {
            
            Console.WriteLine("GetFolderPath: {0}",
                 appPath);
            bool run = true;
            while (run)
            {
                Console.WriteLine("###################################");
                Console.WriteLine("1. add a car");
                Console.WriteLine("2. show all cars");
                Console.WriteLine("3. search for a car");
                Console.WriteLine("4. Delete a car");
                Console.WriteLine("6. to quit");
                Console.WriteLine("###################################");
                int answer = int.Parse(Console.ReadLine());
                Console.WriteLine("\n");
                //declaring the car obj and the cars list for later use
                Car car = new Car();
                var cars = new List<Car>();

                switch (answer){
                    case 1 :
                    {
                        CarHelper.AddCar(car);
                        Console.WriteLine("\n");
                        break;
                    }
                    case 2 :
                    {
                        cars = CarHelper.RetrieveCars();
                        foreach(var item in cars)
                        {
                            Console.WriteLine("Car Id: " + item.Id + "\n Car Brand: " + item.brand + "\n Car Milage: " + item.milage.ToString());
                        }
                        Console.WriteLine("\n");
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("type car id");
                        int id = int.Parse(Console.ReadLine());
                        cars = CarHelper.RetrieveCars();
                        bool x = false;
                        foreach(var item in cars)
                        {
                            if (item.Id == id)
                            {
                                x = true;
                                Console.WriteLine("found car");
                                Console.WriteLine("car brand : "+item.brand);
                                Console.WriteLine("car colour :"+item.colour);
                                Console.WriteLine("car milage :"+item.milage.ToString());
                            }
                           
                        }
                        if (!x)
                        {
                            Console.WriteLine("Car not found Try Again");
                        }
                        Console.WriteLine("\n");
                        break;
                    }
                    case 4:
                    {

                        Console.WriteLine("type car id");
                        int id = int.Parse(Console.ReadLine());
                        cars = CarHelper.RetrieveCars();
                        Car item = cars.Find(x => x.Id == id);
                        if(item != null)
                        {
                            cars.Remove(item);
                            Console.WriteLine("Car with id:" + id + " has been removed");
                        }
                        else
                        {
                            Console.WriteLine("Car Not Found Try Again");
                        }
                        CarHelper.SendListToFile(cars);
                        Console.WriteLine("\n");
                        break;
                    }
                    case 6: { run = false; break; }  
                }
            }
        }
    }
}
