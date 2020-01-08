using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace gym_mgmt_01.Models
{
    [Bind(Exclude = "Id")]
    public class Contact
    {
       
        public Contact() { }
        public int? Id { get; set; }
        public int? MemberID { get; set; }

        [Display(Name = "Email Address")]
        [Remote("IsAlreadyEmail", "Member", HttpMethod = "POST", ErrorMessage = "Email already exists.")]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }


        [Remote("IsAlreadyCell", "Member", HttpMethod = "POST", ErrorMessage = "Cell already exists.")]
        [Required(ErrorMessage = "Cell is required.")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^([0|\+[0-9]{1,4})?([0-9]{8})$", ErrorMessage = " Invalid Mobile Number !!!")]
        public string Cell { get; set; }

        [RegularExpression(@"^([0|\+[0-9]{1,4})?([0-9]{8})$", ErrorMessage = " Invalid Cell Number !!!")]
        [DataType(DataType.PhoneNumber)]
        public string Home { get; set; }

        [RegularExpression(@"^([0|\+[0-9]{1,4})?([0-9]{8})$", ErrorMessage = " Invalid Home Number !!!")]
        [DataType(DataType.PhoneNumber)]
        public string Work { get; set; }

        [MaxLength(150, ErrorMessage = "Address can't be more than 150 characters"), MinLength(5, ErrorMessage = "Address can't be less than 5 characters")]
        public string Address { get; set; }

        [MaxLength(20, ErrorMessage = "Suburb can't be more than 20 characters"), MinLength(5, ErrorMessage = "Suburb can't be less than 5 characters")]
        public string Suburb { get; set; }

        [MaxLength(20, ErrorMessage = "City can't be more than 20 characters"), MinLength(5, ErrorMessage = "City can't be less than 5 characters")]
        public string City { get; set; }

        [Display(Name = " Enter Zipcode ")]
       // [RegularExpression(@"^[0-9]{5}(?:-[0-9]{4})?$", ErrorMessage = " Enter Valid Zipcode. ")]
        [DataType(DataType.PostalCode)]
        public string Zipcode { get; set; }

        public string Subscribed { get; set; }

    }
}