using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace gym_mgmt_01.Models
{
    public class Contact
    {
        public Contact() { }
        public int Id { get; set;  }
        public int MemberID { get; set;  }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set;  }
        [RegularExpression(@"(?:\+971|00971|0)?(?:50|51|52|55|56|2|3|4|6|7|9)\d{7}$", ErrorMessage = " Invalid Mobile Number !!!")]
        public string Cell { get; set;  }

        [RegularExpression(@"(?:\+971|00971|0)?(?:50|51|52|55|56|2|3|4|6|7|9)\d{7}$", ErrorMessage = " Invalid Cell Number !!!")]
        public string Home { get; set;  }

        [RegularExpression(@"(?:\+971|00971|0)?(?:50|51|52|55|56|2|3|4|6|7|9)\d{7}", ErrorMessage = " Invalid Home Number !!!")]
        public string Work { get; set;  } 

        [MaxLength(150, ErrorMessage = "Address can't be more than 150 characters"), MinLength(5, ErrorMessage = "Address can't be less than 5 characters")]
        public string Address { get; set;  }

        [MaxLength(20, ErrorMessage = "Suburb can't be more than 20 characters"), MinLength(5, ErrorMessage = "Suburb can't be less than 5 characters")]
        public string Suburb { get; set;  }

        [MaxLength(20, ErrorMessage = "City can't be more than 20 characters"), MinLength(5, ErrorMessage ="City can't be less than 5 characters")]
        public string City { get; set;  }

        [Display(Name = " Enter Zipcode ")]
        [RegularExpression(@"^[0-9]{5}(?:-[0-9]{4})?$", ErrorMessage = " Enter Valid Zipcode. ")]
        public string Zipcode { get; set;  }

        public string Subscribed { get; set;  }

    }
}