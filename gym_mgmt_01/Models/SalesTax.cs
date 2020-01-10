using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace gym_mgmt_01.Models
{
    public class SalesTax
    {
        public int Id { get; set;  }

        [Required(ErrorMessage =" Please Enter Sales Tax Name ")]
        public String SalesTaxName { get; set;  }

        [Required(ErrorMessage = " Please Enter Sales Tax Value")]
        [Range(0.00 , 9999.00,ErrorMessage =" Value should be in range within 0.00 - 9999.00 ")]
        public String SalesTaxValue { get; set;  }
    }
}