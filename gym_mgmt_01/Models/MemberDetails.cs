using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gym_mgmt_01.Models
{
    public class MemberDetails
    {
        public int Id { get; set; }
        public string FirstName { get; set;  }
        public string LastName  { get; set; }
        public string Gender { get; set;  }
        public string DOB { get; set;  }
        public string ImagePath { get; set;  }
        public int MId { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set;  }
        public int SId { get; set; }

    }
}