using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gym_mgmt_01.Models
{
    public class Role
    { 
        public int Id { get; set;  }
        public string Roles { get; set;  }
        public DateTime CreatedAt { get; set;  }
    }
}