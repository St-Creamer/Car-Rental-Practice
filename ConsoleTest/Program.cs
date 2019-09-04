using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleTest
{
    class Program
    {
        public static string appPath = Directory.GetCurrentDirectory();
        static void Main(string[] args)
        {
            Console.WriteLine("GetFolderPath: {0}", appPath);
            bool run = true;
            while (run)
            {
                //input control
                bool valid = true;

                int answer = -1;

                while (valid)
                {
                    //menu
                    Console.WriteLine("###################################");
                    Console.WriteLine("1. add a car");
                    Console.WriteLine("2. show all cars");
                    Console.WriteLine("3. search for a car");
                    Console.WriteLine("4. Delete a car");
                    Console.WriteLine("6. Update a car ");
                    Console.WriteLine("6. Quit ");
                    Console.WriteLine("###################################");
                    valid = int.TryParse(Console.ReadLine(), out answer);
                    if ((answer < 1 || answer > 7) && valid == false)
                    {
                        valid = false;
                        Console.WriteLine("Please enter a number between 1 and 6");
                    }

                    //declaring the car obj and the cars list for later use
                    Car car = new Car();

                    var cars = new List<Car>();

                    switch (answer)
                    {
                        case 1:
                            {
                                Console.WriteLine("Enter Car Id");
                                car.Id = int.Parse(Console.ReadLine());

                                Console.WriteLine("Enter Car Brand");
                                car.brand = Console.ReadLine();

                                Console.WriteLine("Enter Car Colour");
                                car.colour = Console.ReadLine();

                                Console.WriteLine("Enter Car Milage");
                                car.milage = int.Parse(Console.ReadLine());

                                //if (!File.Exists(appPath + @"\Cars.json"))
                                //{
                                //    var jsonfile = File.Create(appPath + @"\Cars.json");
                                //    jsonfile.Close();
                                //}

                                cars = CarHelper.RetrieveCars();

                                cars.Add(car);

                                CarHelper.SendListToFile(cars);

                                cars.Clear();

                                break;
                            }
                        case 2:
                            {
                                cars = CarHelper.RetrieveCars();

                                foreach (var item in cars)
                                {
                                    Console.WriteLine(item.FullInfo);
                                }

                                Console.WriteLine("\n");

                                cars.Clear();

                                break;
                            }
                        case 3:
                            {
                                cars = CarHelper.RetrieveCars();

                                Console.WriteLine("type car id:");

                                int id = int.Parse(Console.ReadLine());

                                bool x = false;

                                foreach (var item in cars)
                                {
                                    if (item.Id == id)
                                    {
                                        x = true;
                                        Console.WriteLine("found car");

                                        Console.WriteLine(item.FullInfo); ;
                                    }

                                }
                                if (!x)
                                {
                                    Console.WriteLine("Car not found Try Again");
                                }
                                Console.WriteLine("\n");

                                cars.Clear();

                                break;
                            }
                        case 4:
                            {
                                cars = CarHelper.RetrieveCars();

                                Console.WriteLine("type car id:");

                                int id = int.Parse(Console.ReadLine());

                                Car item = cars.Find(x => x.Id == id);

                                if (item != null)
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

                                cars.Clear();

                                break;
                            }
                        case 6:
                            {
                                cars = CarHelper.RetrieveCars();

                                Console.WriteLine("search by id:");

                                int id = int.Parse(Console.ReadLine());

                                int index = -1;

                                foreach (var item in cars)
                                {
                                    if (item.Id == id)
                                    {
                                        index = cars.IndexOf(item);
                                    }
                                }
                                if (index != -1)
                                {

                                    car.Id = id;

                                    Console.WriteLine("Type new Brand");
                                    car.brand = Console.ReadLine();

                                    Console.WriteLine("Type new Colour");
                                    car.colour = Console.ReadLine();

                                    Console.WriteLine("Type new Milage");
                                    car.milage = int.Parse(Console.ReadLine());

                                    cars.Insert(index, car);

                                    cars.RemoveAt(index + 1);

                                    CarHelper.SendListToFile(cars);
                                }
                                else
                                {
                                    Console.WriteLine("Car Not Found");
                                }

                                cars.Clear();

                                break;
                            }
                        case 7:
                            {
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Something went wrong");

                                break;
                            }

                    }
                }
            }
        }
    }
}
