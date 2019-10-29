using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace gym_mgmt_01.Models
{
    public class Member
    {   
        public int Id { get; set;  }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string  LastName { get; set; }
        
        [DisplayName("Date of Birth")]
        public string DOB { get; set; }

        [DisplayName("Gender")]
        public string Gender { get; set; }

        [DisplayName(" Add Notes ")]
        public string note { get; set;  }

        [DisplayName(" Select MemberType  ")]
        public string MemberType { get; set;  }

        [DisplayName("Upload File")]
        public string ImagePath { get; set;  }

    }
}