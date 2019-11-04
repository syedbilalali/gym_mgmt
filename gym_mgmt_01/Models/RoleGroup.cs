using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gym_mgmt_01.Models
{
    public class RoleGroup
    {
        public int Id { get; set; }
        public string GroupName { get; set;  }
        public string Description { get; set;  }
        public DateTime CreatedAt { get; set;  }
    }
}