using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gym_mgmt_01.Models
{
    public class Stocks
    {
        public int Id { get; set; }
        public int product_Id { get; set;  }
        public decimal get_price { get; set;  }
        public decimal sell_price { get; set;  }
        public int stockin { get; set;  }
        public int stockout { get; set; }
        public int current_stock { get; set;  }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;  }
        public string product_name { get; set;  }
    }
}