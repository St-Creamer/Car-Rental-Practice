using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

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
            if (!Regex.IsMatch(x, @"^[a-zA-Z]+$"))
            {
                this.milage = int.Parse(x);
            }


            string json = JsonConvert.SerializeObject(this, Formatting.Indented);


            using (StreamWriter sw = File.AppendText(@"c:\Users\RIP\Desktop\c# console\ConsoleTest\ConsoleTest\Cars.json"))
            {
                sw.WriteLine(json);

            }

        }


    }
}
