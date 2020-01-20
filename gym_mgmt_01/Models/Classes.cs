using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using gym_mgmt_01.Helper_Code.Common;

namespace gym_mgmt_01.Models
{
    public class Classes
    {
        public int Id { get; set; }


        [Required(ErrorMessage =" Class Name required")]
        [StringLength(60)]
        public string ClassName { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm tt}")]
        [DataType(DataType.Time)]
        //  [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        //[Remote("checkdata", "Training", HttpMethod = "POST", ErrorMessage = "EmailId already exists in database.")]
        public DateTime? From { get; set; }


        public string FromStr { get; set;  }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm tt}")]
        [DataType(DataType.Time)]
         //[DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        //[MyDate(ErrorMessage = "Back date entry not allowed")]
       //[DateGreaterThanAttribute(otherPropertyName = "From", ErrorMessage = "End date must be greater than start date.")]
        //[Remote("checkdata", "Training", HttpMethod = "POST", ErrorMessage = "End date must be greater than start date")]
        public DateTime? To { get; set; }
        public string ToStr { get; set;  } 
        public string Repeats { get; set;  }
        public DateTime RepeatsEnd { get; set; }
        public string Resource { get; set; }
        public int StaffID { get; set;  }
        public string StaffName { get; set;  }
        public string Note { get; set;  }
        public DateTime CreatedAt { get; set;  }
    }
}