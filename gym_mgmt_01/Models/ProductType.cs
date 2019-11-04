using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace gym_mgmt_01.Models
{
    public class ProductType
    { 
        public int Id { get; set; }
        [Required]
        public string TypeName { get; set;  }

        [Required]
        public string TaxRateName { get; set;  }
        public string SoldInClubs { get; set;  }
        public DateTime CreatedAt { get; set;  }
    }
}