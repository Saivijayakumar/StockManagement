using System;
using System.IO;
using Newtonsoft.Json;


namespace StockManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=====>Welcome To Stock Management<======\n");
            StockMethods methods = new StockMethods();
            string filePath = @"C:\Users\SaiVijay\source\repos\StockManagement\StockManagement\JsonFile.json";
            //converting json file into object
            StockDetails stock = JsonConvert.DeserializeObject<StockDetails>(File.ReadAllText(filePath));
            Console.WriteLine("Chose your option");
            Console.WriteLine("\n1. Display Stocks\n");
            Console.WriteLine("2. Calculate values for each stocks\n");
            Console.WriteLine("3. Calculate total stocks\n");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    methods.ShowDetails(stock.StocksList);
                    break;
                case 2:
                    methods.EachShareValue(stock.StocksList);
                    break;
                case 3:
                    methods.TotalShareValue(stock.StocksList);
                    break;
                default:
                    Console.WriteLine("Enter Valid Option");
                    break;
            }
            Console.Read();

        }
    }
}
