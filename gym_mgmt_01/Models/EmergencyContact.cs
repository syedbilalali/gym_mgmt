using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gym_mgmt_01.Models
{
    public class EmergencyContact
    {  

       public int Id { get; set;  }
       public string FirstName { get; set;  }
       public string LastName { get; set;  }
       public string Relationship { get; set;  }
       
        public string Email { get; set;  }
        public string Cell { get; set;  }
        public string Home { get; set;  }
        public string  Work { get; set;  }
        public string MedicalInfo { get; set;  }
        public string Age { get; set;  }

    }
}