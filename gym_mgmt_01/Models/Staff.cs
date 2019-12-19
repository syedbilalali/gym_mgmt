using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace gym_mgmt_01.Models
{
    public class Staff
    {
        public string StaffID { get; set;  }
        [Display(Name = "First   Name")]
        [Required(ErrorMessage = " First Name Required. ")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = " Please enter valid name. ")]
        public string FirstName { get; set;  }



        [Required(ErrorMessage = " Last Name Required. ")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = " Please enter valid name. ")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        [DateMinimumAge(18, ErrorMessage = "{0} must be someone at least {1} years of age")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = " Please enter Date of Birth. ")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = " Please Choose Gender. ")]
        public string Gender { get; set;  }

        [Required(ErrorMessage = " Please Choose Designation. ")]
        public string Designation { get; set;  }

        [Required(ErrorMessage = " Please Enter Password. ")]
        public string Password { get; set;  }
        public string ImgURL { get; set; }

        public HttpPostedFileBase PostedFile { get; set; }
        public string permission { get; set;  }


    }
}