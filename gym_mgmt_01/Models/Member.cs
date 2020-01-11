using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using System.Web;

namespace gym_mgmt_01.Models
{
    
    public class Member
    {

        public Member() {
            note = "";
        }
        public int? Id { get; set; } 

        [DisplayName("First Name")]
        [Required(ErrorMessage = " First Name Required. ")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = " Please enter valid name. ")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = " Last Name Required. ")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = " Please enter valid name. ")]
        public string LastName { get; set; }

        [DisplayName("Date of Birth")]
        [Required(ErrorMessage = " Please enter Date of Birth. ")]
        [DateMinimumAge(18, ErrorMessage = "{0} must be someone at least {1} years of age")]
        public string DOB { get; set; }

        [DisplayName("Gender")]
        [Required(ErrorMessage = " Please choose gender. ")]
        public string Gender { get; set; }

        [DisplayName(" Add Notes ")]
        public string note { get; set; }

        [DisplayName(" Select MemberType  ")]
        public string MemberType { get; set; }

        [DisplayName("Upload File")]
        public string ImagePath { get; set; }
        public string ImageUri { get; set; }
        public HttpPostedFileBase ImageFile { get; set;}

    }
    public class DateMinimumAgeAttribute : ValidationAttribute
    {
        public DateMinimumAgeAttribute(int minimumAge)
        {
            MinimumAge = minimumAge;
            ErrorMessage = "{0} must be someone at least {1} years of age";
        }
        public override bool IsValid(object value)
        {
            DateTime date;
            if ((value != null && DateTime.TryParse(value.ToString(), out date)))
            {
                return date.AddYears(MinimumAge) < DateTime.Now;
            }
            return false;
        }
        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name, MinimumAge);
        }
        public int MinimumAge { get; }
    }
    public class DateRange : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date = DateTime.Parse(value.ToString());
            int years = int.Parse(date.Year.ToString());
            if (years >= 1900 && years <= 9999) {
                return true;
            }
            return false;
        }
    }
}