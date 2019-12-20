using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace gym_mgmt_01.Models
{
    public class Membership : IValidatableObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage = " First Name Required. ")]
        [RegularExpression(@"^(?!\d+$)(?![_\s]+$)[A-Za-z0-9\s_]+$", ErrorMessage = " Please enter valid name. ")]
        public string Name { get; set; }
        public string Description { get; set; }
        public int ValidDays {get; set; }

        [Required]
        [RegularExpression(@"^[0-9]\d{0,9}(\.\d{1,3})?%?$", ErrorMessage = " Please enter valid amount. ")]
        public decimal Amount { get; set;  }

        [Required(ErrorMessage ="Start Date is required. ")]
        public DateTime StartDate { get; set;  }

        public string sStartDate { get; set;  }


        [Required(ErrorMessage = "End Date is required. ")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Remote("CheckStartDate", "Membership", HttpMethod = "POST", ErrorMessage = "Course already exists.")]
        public DateTime EndDate { get; set; }
        public string sEndDate { get; set;  }

        [Range(0, 50, ErrorMessage = "Enter number between range 0 and 50")]
        public int PreExpirationDays { get; set;  }
        public DateTime PreEndDate { get; set;  }

        [Required]
        public int Capacity { get; set;  }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            if (EndDate > StartDate)
            {
                yield return new ValidationResult("endDate must be greater than start date");
            }
        }
    }
}