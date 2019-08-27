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
            string json = File.ReadAllText(Program.appPath+ @"\Cars.json");
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
            using (StreamWriter sw = File.CreateText(Program.appPath + @"\Cars.json"))
            {
                sw.WriteLine(json);
            }
        }
    }
}
