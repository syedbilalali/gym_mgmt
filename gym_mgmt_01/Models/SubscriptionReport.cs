using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gym_mgmt_01.Models
{
    public class SubscriptionReport
    {
        public int Id { get; set; }
        public string  MembershipName { get; set;}
        public decimal Amount { get; set;  }
        public DateTime ExpiryDate { get; set;  }
        public string Capacity { get; set;  }
        public string MemberName { get; set;  }
        public string PaymentStatus { get; set;  }
        public decimal PaidAmount { get; set;  }
    }
}