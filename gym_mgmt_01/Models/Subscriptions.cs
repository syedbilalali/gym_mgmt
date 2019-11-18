using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace gym_mgmt_01.Models
{
    public class Subscriptions
    { 
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
    }
}