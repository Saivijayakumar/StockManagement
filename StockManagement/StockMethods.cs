using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
