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
            Console.WriteLine("\n1. Display Stocks\n2. Calculate values for each stocks\n3. Calculate total stocks\n4. Add a Stock\n5. Remove a Stock\n");
            
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
                case 4:
                    methods.AddStock(stock.StocksList);
                    File.WriteAllText(filePath, JsonConvert.SerializeObject(stock));
                    Console.WriteLine("----------------------------");
                    methods.ShowDetails(stock.StocksList);
                    break;
                case 5:
                    methods.RemoveStock(stock.StocksList);
                    File.WriteAllText(filePath, JsonConvert.SerializeObject(stock));
                    Console.WriteLine("----------------------------");
                    methods.ShowDetails(stock.StocksList);
                    break;
                default:
                    Console.WriteLine("Enter Valid Option");
                    break;
            }
            Console.WriteLine("----------User Methods------------");
            Console.WriteLine("Chose your option");
            Console.WriteLine("\n1. Display Stocks\n2. Buy stocks\n3. sell stocks\n");

            int options = Convert.ToInt32(Console.ReadLine());
            switch (options)
            {
                case 1:
                    methods.UsersStocks(stock.UserList);
                    break;
                case 2:
                    methods.BuyStock(filePath);
                    break;
                case 3:
                    methods.SellStock(filePath);
                    break;
                default:
                    Console.WriteLine("Enter Valid Option");
                    break;
            }
            Console.Read();

        }
    }
}
