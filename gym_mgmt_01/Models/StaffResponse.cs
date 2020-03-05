using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gym_mgmt_01.Models
{
    public class StaffResponse
    {
        public string Name { get; set; }
        public string Designation { get; set; }
        //   public string Contact { get; set;  }
        public string Email { get; set; }
        public string ProfileURI { get; set; }
        public string data { get; set; }
        public StaffResponse(string Name, string Designation, string Email, string ProfileURI, string data)
        {
            this.Name = Name;
            this.Designation = Designation;
            this.Email = Email;
            this.ProfileURI = ProfileURI;
            this.data = data;
        }
    }
}