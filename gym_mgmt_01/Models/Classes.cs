using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gym_mgmt_01.Models
{
    public class Classes
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Repeats { get; set;  }
        public DateTime RepeatsEnd { get; set; }
        public string Resource { get; set; }
        public int StaffID { get; set;  }
        public string Note { get; set;  }
        public DateTime CreatedAt { get; set;  }
    }
}