using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gym_mgmt_01.Models
{
    public class SellsOrder
    {
        public int Id { get; set;  }
        public string Invoice_number { get; set;  }
        public string Member_Name { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Sales_Tax { get; set;  }
        public decimal Total_Amount { get; set;  }
        public string Paid_Status { get; set;  }
        public decimal Total_Pay { get; set; }
        public decimal Discount_Price { get; set; }
        public decimal Remain_price { get; set; }
        public DateTime CreatedAt { get; set; }


    }
}