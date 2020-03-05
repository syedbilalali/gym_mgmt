using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gym_mgmt_01.Models
{
    public class MemberResponse
    {
        // public int? Id;
        public string Name;
        public string Membership;
        public string Phone;
        public string JoinDate;
        public string ExpiredDate;
        public string ProfileURI;
        public string data;
        public MemberResponse(int? Id, string Name, string Phone, string Membership, string JoinDate, string ExpiredDate, string ProfileURI, string data)
        {

            //  this.Id = Id;
            this.Name = Name;
            this.Phone = Phone;
            this.Membership = Membership;
            this.JoinDate = JoinDate;
            this.ExpiredDate = ExpiredDate;
            this.ProfileURI = ProfileURI;
            this.data = data;
        }
    }
}