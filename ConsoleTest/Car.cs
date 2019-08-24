using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleTest
{
    class Car
    {
        public int Id { get; set; }
        public string brand { get; set; }
        public string colour { get; set; }
        public int milage { get; set; }

        public  Car()
        {
            this.milage = 0;
        }
        public void AddCar(Car car)
        {
            Console.WriteLine("Enter Car Id");
            this.Id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Car Brand");
            this.brand = Console.ReadLine();

            Console.WriteLine("Enter Car Colour");
            this.colour = Console.ReadLine();

            Console.WriteLine("Enter Car Milage Or \"n\" if not needed");

            string x = Console.ReadLine();
            if (x != "n")
            {
                this.milage = int.Parse(x);
            }
            using (StreamWriter file = File.AppendText(@"c:\Users\RIP\Desktop\c# console\ConsoleTest\ConsoleTest\Cars.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, this);
            }
        }


    }
}
