﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gym_mgmt_01.Models
{
    public class ClassSubscriptions
    { 
        public int Id { get; set;  }
        public int ClassID { get; set;  }
        public int MemberID { get; set;  }
        public DateTime CreatedAt { get; set;  }
        public string ClassName { get; set;  }
        public string MemberName { get; set; }
        public string TrainnerName { get; set;  }
        public DateTime ExpirayDate { get; set; }
        public DateTime FromTime { get; set;  }
        public DateTime ToTime { get; set;  }
    }
}