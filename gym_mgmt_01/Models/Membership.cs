﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace gym_mgmt_01.Models
{
    public class Membership
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ValidDays {get; set; }
        public decimal Amount { get; set;  }
        public DateTime StartDate { get; set;  }
        public DateTime EndDate { get; set; }
        public DateTime PreEndDate { get; set;  }
        public int Capacity { get; set;  }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}