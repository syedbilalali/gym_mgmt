﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace gym_mgmt_01.Models
{
    public class Subscriptions
    {
        public Subscriptions() { }
        public Subscriptions(decimal TotalCost , decimal LeftCOst , int id) {
            this.Total_Amount = TotalCost;
            this.LeftSubscriptionCost = LeftCOst;
            this.Id = id;
        }
        public int Id { get; set; }

        [Required, Display(Name = "Please select Membership ")]
        public int MembershipID { get; set; }

        [Required, Display(Name = " Please select Member ")]
        public int MemberID { get; set; }
        public DateTime CreatedAt { get; set; }

        public string MembershipName { get; set; }
        public decimal Ammount { get; set; }
        public DateTime ExpirayDate { get; set; }
        public string MemberName { get; set; }

        public decimal Total_Amount { get; set; }

        [Required , Display(Name="Please enter Paid Amount.")]
        
        public decimal Paid_Amount { get; set; }

        public decimal Due_Amount { get; set; }

        [Required , Display(Name ="Please select the Paid Status")]
        public string Paid_Status { get; set; }

        public string Status { get; set; }

      //  [DataType(DataType.Date)]
      //  [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
          public DateTime StartDate { get; set; }
         public string sStartDate { get; set; }



     //   [DataType(DataType.Date)]
     //   [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        public string sEndDate { get; set; }

        public decimal LeftSubscriptionCost { get; set;  }

    }
}