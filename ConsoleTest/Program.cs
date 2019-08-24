using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. add a car");
            Console.WriteLine("2. show all cars");
            Console.WriteLine("3. search for a car");
            int answer = int.Parse(Console.ReadLine());
            

            
            
            switch (answer){
               case 1 :
                    {
                        Car car = new Car();
                        CarHelper carHelper = new CarHelper();
                        carHelper.AddCar(car);
                        break;
                    }
                case 2 :
                    {
                        string cars = File.ReadAllText(@"c:\Users\RIP\Desktop\c# console\ConsoleTest\ConsoleTest\Cars.json");
                        Console.WriteLine(cars);
                        //using (StreamReader file = File.OpenText(@"c:\Users\RIP\Desktop\c# console\ConsoleTest\ConsoleTest\Cars.json"))
                        //{
                        //    JsonSerializer serializer = new JsonSerializer();
                        //    Car car = (Car)serializer.Deserialize(file, typeof(Car));
                        //}
                        break;

                    }
                case 3:
                    {
                        Console.WriteLine("type car id");
                        int id = int.Parse(Console.ReadLine());
                        string json = File.ReadAllText(@"c:\Users\RIP\Desktop\c# console\ConsoleTest\ConsoleTest\Cars.json");
                     
                        var cars = JsonConvert.DeserializeObject<List<Car>>(json);
                        foreach(var car in cars)
                        {
                            if (car.Id == id)
                            {
                                Console.WriteLine("found car");
                                Console.WriteLine(car.brand);
                                Console.WriteLine(car.colour);

                            }
                            else
                            {
                                Console.WriteLine("car not found");
                            }
                        }
                        
                        break;
                    }
            }

            


        }
    }
}
