using System.Collections.Generic;


namespace StockManagement
{
    class StockDetails
    {
        //json list name and our list name should be same
        public List<Stockc> StocksList { get; set; }
        public List<UserStock> UserList { get; set; }


        public class Stockc
        {
            public string name { get; set; }
            public int volume { get; set; }
            public int price { get; set; }
        }

        public class UserStock
        {
            public string name { get; set; }
            public int volume { get; set; }
            public int price { get; set; }
        }

    }


}
