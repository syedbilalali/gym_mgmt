using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gym_mgmt_01.Models
{
    public class Prospectus
    {
        public int id { get; set;  }
        public string ContactMethod { get; set; }
        public string FitnessGoal { get; set; }
        public string PreviousGym { get; set; }
        public string LeadStrength { get; set; }
        public string Created { get; set; }
    }
}