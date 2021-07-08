using System.Collections.Generic;


namespace StockManagement
{
    interface IStockMethods
    {
        void ShowDetails(List<StockDetails.Stockc> stocksList);
        void EachShareValue(List<StockDetails.Stockc> stocksList);
        void TotalShareValue(List<StockDetails.Stockc> stockList);
        void AddStock(List<StockDetails.Stockc> stockList);
        void RemoveStock(List<StockDetails.Stockc> stockList);
        void UsersStocks(List<StockDetails.UserStock> userStocksList);
        void BuyStock(string patthref);
        void SellStocks(string pathref);
    }
}
