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
            Console.WriteLine("4. Edit an existing car");
            int answer = int.Parse(Console.ReadLine());


            Car car = new Car();
            var cars = new List<Car>();

            switch (answer){
               case 1 :
                    {
                        
                        CarHelper.AddCar(car);
                        break;
                    }
                case 2 :
                    {
                         cars = CarHelper.RetrieveCars();
                        foreach(var item in cars)
                        {
                            Console.WriteLine("Car Id: " + item.Id + "\n Car Brand: " + item.brand + "\n Car Milage :" + item.milage.ToString());
                        }
                        break;

                    }
                case 3:
                    {
                        Console.WriteLine("type car id");
                        int id = int.Parse(Console.ReadLine());
                         cars = CarHelper.RetrieveCars();
                        foreach(var item in cars)
                        {
                            if (item.Id == id)
                            {
                                Console.WriteLine("found car");
                                Console.WriteLine("car brand : "+item.brand);
                                Console.WriteLine("car colour :"+item.colour);
                                Console.WriteLine("car milage :"+item.milage.ToString());

                            }
                            else
                            {
                                Console.WriteLine("car not found");
                            }
                        }
                        
                        break;
                    }
                case 4:
                    {

                        Console.WriteLine("type car id");
                        int id = int.Parse(Console.ReadLine());

                         cars = CarHelper.RetrieveCars();
                        foreach (var item in cars)
                        {
                            if (item.Id == id)
                            {
                                
                                cars.Remove(item);
                                Console.WriteLine("Car with id" + id + " has been removed");
                                CarHelper.SendListToFile(cars);
                                

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
