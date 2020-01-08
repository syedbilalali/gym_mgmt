using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace gym_mgmt_01.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type_Id { get; set;  }
        public int Supplier_Id { get; set;  }
        public int POS_group_Id { get; set;  }
        public string Barcode { get; set;  }
        public string Description { get; set;  }
        public string ImageURL { get; set;  }
        public string CurrentStock { get; set; }
        public DateTime CreatedAt { get; set;  }
    }
}