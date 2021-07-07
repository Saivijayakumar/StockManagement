using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace StockManagement
{
    class StockMethods: IStockMethods
    {
        public void ShowDetails (List<StockDetails.Stockc> stocksList)
        {
            Console.WriteLine("The stock Details are\n");
            foreach (StockDetails.Stockc i in stocksList)
            {
                Console.WriteLine($"Company Name :{i.name}");
                Console.WriteLine($"Volume  :{i.volume}");
                Console.WriteLine($"Price  :{i.price}");
                Console.WriteLine("\n");
            }
        }
        public void EachShareValue(List<StockDetails.Stockc> stocksList)
        {
            int eachValue = 0;
            foreach(StockDetails.Stockc i in stocksList)
            {
                eachValue = i.volume * i.price;
                Console.WriteLine($"Stock Price for {i.name} is {eachValue}");
            }
        }
        public void TotalShareValue(List<StockDetails.Stockc> stockList)
        {
           int total = 0;
            foreach(StockDetails.Stockc i in stockList)
            {
                total += i.volume * i.price;
            }
            Console.WriteLine($"The Total share value is :{total}");
        }

        public void AddStock(List<StockDetails.Stockc> stockList)
        {
            StockDetails.Stockc dummy = new StockDetails.Stockc();
            Console.Write("Enter Name :");
            dummy.name = Console.ReadLine();
            Console.Write("Enter Volume :");
            dummy.volume = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Price :");
            dummy.price = Convert.ToInt32(Console.ReadLine());
            stockList.Add(dummy);
        }
        public void RemoveStock(List<StockDetails.Stockc> stockList)
        {
            Console.WriteLine("Enter Name :");
            string stockName = Console.ReadLine();
            stockList.Remove(stockList.Find(ut => ut.name.Equals(stockName)));
        }

        public void UsersStocks(List<StockDetails.UserStock> userStocksList)
        {
            int total = 0;
            Console.WriteLine("The stock Details are\n");
            foreach (StockDetails.UserStock i in userStocksList)
            {
                Console.WriteLine($"Company Name :{i.name}");
                Console.WriteLine($"Volume  :{i.volume}");
                Console.WriteLine($"Price  :{i.price}");
                Console.WriteLine("\n");
                total += i.volume * i.price;
            }
            Console.WriteLine($"Total stock worth : {total}");

        }
        public void BuyStock(string patthref)
        {
            StockDetails buyStockList = JsonConvert.DeserializeObject<StockDetails>(File.ReadAllText(patthref));
            ShowDetails(buyStockList.StocksList);
            UsersStocks(buyStockList.UserList);
            Console.WriteLine("Enter the name of the stock you want to buy:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter how many volumes you want to buy:");
            int volume = Convert.ToInt32(Console.ReadLine());
            bool check = CheckAvailablity(name, volume, buyStockList.StocksList);
            if (check)
            {

                StockDetails.Stockc result = buyStockList.StocksList.Find(item => item.name.Equals(name));
                result.volume -= volume;
                Console.WriteLine(result.volume);
                StockDetails.UserStock user = new StockDetails.UserStock();
                user.name = name;
                user.volume = volume;
                user.price = result.price;
                if (buyStockList.UserList.Find(item => item.name.Equals(user.name))))
                {
                    //StocksUtility.UserStocks res = utilityOfStockList.userStockList.Find(item => item.name.Equals(user.name));
                    foreach (StockDetails.UserStock i in buyStockList.UserList)
                    {
                        if (i.name.Equals(name) && i.volume >= volume)
                        {
                            i.volume += user.volume;

                        }
                    }

                }
                else
                {
                    
                }

                File.WriteAllText(patthref, JsonConvert.SerializeObject(buyStockList));
                Console.WriteLine("********Purchased success*************");
                Console.WriteLine($"You Purchased {user.name} of volume = {user.volume} , worth = {user.volume * user.price} ");


            }
            else
            {
                Console.WriteLine(" Stock Not available");
            }

        }
        public bool CheckAvailablity(string nameOfStock, int volumeOfStock, List<StockDetails.Stockc> stockList)
        {
            StockDetails.Stockc result = stockList.Find(item => item.name.Equals(nameOfStock));
            if (result.name.Equals(nameOfStock) && result.volume >= volumeOfStock)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
