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
        [Required(ErrorMessage =" First Name Required. ")]
        [RegularExpression(@"^[a-zA-Z]+$" , ErrorMessage ="Please enter valid name. ")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = " Last Name Required. ")]
        [RegularExpression(@" ^[a-zA-Z]+$", ErrorMessage = "Please enter valid name. ")]
        public string  LastName { get; set; }
        
        [DisplayName("Date of Birth")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = " Please enter Date of Birth. ")]
        public string DOB { get; set; }

        [DisplayName("Gender")]
        [Required(ErrorMessage = " Please choose gender. ")]
        public string Gender { get; set; }
        [DisplayName(" Add Notes ")]
        public string note { get; set;  }

        [DisplayName(" Select MemberType  ")]
        public string MemberType { get; set;  }

        [DisplayName("Upload File")]
        public string ImagePath { get; set;  }

    }
}