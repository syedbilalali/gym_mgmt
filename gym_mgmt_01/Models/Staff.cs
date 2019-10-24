using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gym_mgmt_01.Models
{
    public class Staff
    {
        public string Id { get; set;  }
        public string FirstName { get; set;  }
        public string LastName { get; set; }
        public DateTime dob { get; set;  }
        public string Gender { get; set;  }
        public string Designation { get; set;  }

    }
}