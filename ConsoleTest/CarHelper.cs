using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleTest
{
    class CarHelper
    {
        //gets the list of cars from the json file
        public static List<Car> RetrieveCars()
        {
            var  json="[]";

            try
            {
                 json = File.ReadAllText(Program.appPath + @"\Cars.json");
            }
            catch (FileNotFoundException)
            {
                using (StreamWriter sw = File.CreateText(Program.appPath+@"\Cars.json"))
                {
                    sw.WriteLine("[]");
                }
            }

            var retrievedlist = JsonConvert.DeserializeObject<List<Car>>(json);

            if (retrievedlist.Count == 0)
            {
                Console.WriteLine("Car list is empty please add a car");
            }
            return retrievedlist;
        }
        //sends the list of cars to the json fole
        public static void SendListToFile(List<Car> cars)
        {
            string json = JsonConvert.SerializeObject(cars);

            using (StreamWriter sw = File.CreateText(Program.appPath + @"\Cars.json"))
            {
                sw.WriteLine(json);
            }
        }
    }
}
