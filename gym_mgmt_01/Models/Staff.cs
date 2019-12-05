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


        [Required(ErrorMessage = "First Name is Required")]
        [StringLength(30, MinimumLength = 4,
                  ErrorMessage = "First name should be between 4 and 30 characters")]
        public string FirstName { get; set;  }

        [Required(ErrorMessage = "Last Name is Required")]
        [StringLength(30, MinimumLength = 4,
                  ErrorMessage = "Last name should be between 4 and 30 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        public string Email { get; set; }
        public DateTime DOB { get; set; }

        [Required]
        public string Gender { get; set;  }
        public string Designation { get; set;  }
        public string Password { get; set;  }
        public string ImgURL { get; set; }


    }
}