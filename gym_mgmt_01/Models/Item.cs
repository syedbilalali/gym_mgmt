using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gym_mgmt_01.Models
{
    public class Item
    {
            public int ItemID { get; set; }
            public string ItemName { get; set; }
            public int StockID { get; set; }
            public decimal Qty { get; set; }
            public decimal SellPrice { get; set; }
    }
}