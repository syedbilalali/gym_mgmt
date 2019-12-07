using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace gym_mgmt_01.Models
{
    public class RoleGroup
    {
        public int Id { get; set; }

        [Required]
        [Remote("IsAlreadyGroup", "Role", HttpMethod = "POST", ErrorMessage = "Module already exists in database.")]
        public string GroupName { get; set;  }
        public string Description { get; set;  }
        [Required]
        public string Access { get; set;  }
        public DateTime CreatedAt { get; set;  }
    }
}