using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace gym_mgmt_01.Models
{
    public class SusbscriptionInvoice
    {
        public SusbscriptionInvoice() { }
        public SusbscriptionInvoice(decimal Amount  , decimal Due_Amount , int subscriptionID) {
            this.SubscriptionID = subscriptionID;
            this.LeftSubscriptionCost = Due_Amount;
            this.Total_Amount = Amount;
        }
        public int Id { get; set; }
        public int SubscriptionID { get; set;  }
        public decimal Total_Amount { get; set; }
        [Required, Display(Name = "Please enter Paid Amount.")]
        public decimal Paid_Amount { get; set;  }
        public decimal Due_Amount { get; set;  }

        [Required, Display(Name = "Please select the Paid Status")]
        public string Paid_Status { get; set;  }
        public decimal LeftSubscriptionCost { get; set; }
        public DateTime CreatedAt { get; set;  }
    }
}