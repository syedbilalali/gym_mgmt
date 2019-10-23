using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gym_mgmt_01.Models
{
    public class Member
    {   
        public int Id { get; set;  }
        public string FirstName { get; set; }
        public string  LastName { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public string note { get; set;  }
        public string ImgURL { get; set;  }
    }
}