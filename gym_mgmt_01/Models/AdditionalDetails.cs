using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gym_mgmt_01.Models
{
    public class AdditionalDetails
    {   
        public int Id { get; set;  }
        public int Club { get; set; } 
        public int TrainerID { get; set; }
        public int JoiningDate { get; set;  }
        public int SalesRepID { get; set;  }

        public int SourcePromotionID { get; set;  }
        public int ReferredMemberBy { get; set;  }
        public string Occupation { get; set; }
        public string Organisation { get; set; }

        public string InvolvementType { get; set;  }
    }
}