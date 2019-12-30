using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gym_mgmt_01.Models
{
    public class ModuleDetails
    {
        public string Module { get; set; }
        public string status { get; set; }
        public bool isSelected { get; set;  }
        public bool View { get; set; }
        public bool Edit { get; set; }
        public bool Create { get; set;  }
        public bool Delete { get; set;  }
    }
}