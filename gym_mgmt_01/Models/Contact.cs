﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace gym_mgmt_01.Models
{
    public class Contact
    {
        public Contact() { }
        public string Id { get; set;  }
        public int MemberID { get; set;  }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set;  }
        public string Cell { get; set;  }
        public string Home { get; set;  }
        public string Work { get; set;  }
        public string Address { get; set;  }
        public string Suburb { get; set;  }
        public string City { get; set;  }
        public string Zipcode { get; set;  }

        public string Subscribed { get; set;  }

    }
}