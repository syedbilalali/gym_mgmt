using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gym_mgmt_01.Models
{
    public class Staff
    {
        public string StaffID { get; set;  }
        public string FirstName { get; set;  }
        public string LastName { get; set; }
        public string Email { get; set; } 
        public DateTime DOB { get; set;  }
        public string Gender { get; set;  }
        public string Designation { get; set;  }
        public string Password { get; set;  }
        public string ImgURL { get; set; }


    }
}