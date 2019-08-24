using Newtonsoft.Json;
using System;
using System.IO;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. add a car");
            Console.WriteLine("2. show all cars");

            int answer = int.Parse(Console.ReadLine());
            

            
            
            switch (answer){
               case 1 :
                    {
                        Car car = new Car();
                        car.AddCar(car);
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
            }

            


        }
    }
}
