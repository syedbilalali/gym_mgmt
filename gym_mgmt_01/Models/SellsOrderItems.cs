    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gym_mgmt_01.Models
{
    public class SellsOrderItems
    {
        public int Id { get; set; }
        public int Invoice_Id { get; set; }
        public int product_Id { get; set; }
        public decimal quantity { get; set;  }
        public decimal unit_price { get; set;  }
        public decimal discount_price { get; set;  }
        public decimal total_ammount { get; set; }
        public DateTime CreatedAt { get; set;  }
    }
}