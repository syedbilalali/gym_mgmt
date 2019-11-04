using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gym_mgmt_01.Models
{
    public class UserRoles
    { 
        public int Id { get; set;  }
        public int RoleGroupID { get; set;  }
        public int RoleID { get; set; }
        public int UserID { get; set;  }
        public DateTime CreatedAt { get; set;  }

    }
}