using System.Collections.Generic;


namespace StockManagement
{
    interface IStockMethods
    {
        void ShowDetails(List<StockDetails.Stockc> stocksList);
        void EachShareValue(List<StockDetails.Stockc> stocksList);
        void TotalShareValue(List<StockDetails.Stockc> stockList);
    }
}
