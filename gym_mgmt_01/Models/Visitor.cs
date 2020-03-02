using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gym_mgmt_01.Models
{
    public class Visitor
    { 
        public int VisitorID { get; set; }
        public int UserID { get; set; }
        public string VisitorName { get; set; }
        public string UserType { get; set; }
        public string Date { get; set; }
        public string Clock { get; set; }
        public string ClockIn { get; set; }
        public string ClockOut { get; set; }
        public string Total_Hour { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt  { get; set; }
    }
}