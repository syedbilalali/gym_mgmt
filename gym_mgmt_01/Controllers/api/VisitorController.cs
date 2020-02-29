using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using gym_mgmt_01.BAL.Master;
using gym_mgmt_01.Models;

namespace gym_mgmt_01.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/visit")]
    public class VisitorController : ApiController
    {
        MemberOperation mo = new MemberOperation();
        MembershipOpt mbr = new MembershipOpt();
        SubscriptionOpt sub = new SubscriptionOpt();
        ContactOpration co = new ContactOpration();
        VisitorOpration vo = new VisitorOpration();
        [HttpGet, AllowAnonymous, Route("loginA")]
        public HttpResponseMessage  Get() {
         //   Emp e = new Emp("bilal" , "123");
            return Request.CreateResponse(HttpStatusCode.OK, new Message(HttpStatusCode.OK, "Login Successfully" , "success"));
        }
        [HttpPost, AllowAnonymous, Route("login")]
        public HttpResponseMessage GetCheckIn(string userid) {
            
            try {
                if (userid != null)
                {
                    Member mem = mo.getMember(int.Parse(userid));
                    Contact con = co.GetContact(int.Parse(userid));
                    if (mem != null && mem.Id !=  null  && mem.Id != 0)
                    {
                       
                        Subscriptions sbs = sub.getSubscriptionByMemberID(mem.Id);
                        MembershipOpt mo = new MembershipOpt();
                        if (sbs != null  && sbs.Id != 0)
                        {
                            Membership mbr = mo.getMembershipByID(sbs.MembershipID);
                            TimeSpan timeSpan = mbr.EndDate - DateTime.Now;
                            if (timeSpan.Days >= 0)
                            {
                                MemberResponse mr = new MemberResponse(mem.Id, mem.FirstName + " " + mem.LastName, con.Cell,mbr.Name ,  mbr.StartDate.ToShortDateString(), mbr.EndDate.ToShortDateString(), mem.ImagePath);
                                Visitor visit = new Visitor();
                                visit.UserID = int.Parse(mem.Id.ToString());
                                    visit.UserType = "Member";
                                    visit.Date = DateTime.Today.ToShortDateString();
                                    visit.ClockIn = DateTime.Now.ToShortTimeString();
                                    visit.Status = "";
                                vo.AddVisit(visit);
                                return Request.CreateResponse(HttpStatusCode.OK, mr);
                            }
                            else {
                                return Request.CreateResponse(HttpStatusCode.NotFound, new Message(" Sorry You Membership has expired !!! "));
                            }
                           
                        }
                        else {
                            return Request.CreateResponse(HttpStatusCode.NotFound , new Message(" Sorry Membership Not Found !!! "));
                        }
                    }
                    else {
                        return Request.CreateResponse(HttpStatusCode.NotFound , new Message(" Sorry Userid Not Found !!! ")); 
                    }
                }
                else {
                    return Request.CreateResponse(HttpStatusCode.BadRequest , new Message(" Sorry Userid is mandatory !!! "));
                }

            }
            catch (Exception e) {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Please Contact to Server Adminstrator !!! ");
            }
        }
    }
    public class Message {

       // public string msg;
       // public HttpStatusCode code;
      //  public string status;
        public object data;

        public Message(Object data) {
            this.data = data;
        }
        public Message(HttpStatusCode code, string msg , string status) {
         //   this.code = code;
         //   this.msg = msg;
         //   this.status = status;
        }
        public Message(HttpStatusCode code, string msg, string status, object data)
        {
         //   this.code = code;
          //  this.msg = msg;
         //   this.status = status;
            this.data = data;
        }
    }
    public class MemberResponse {

        public int? Id;
        public string Name;
        public string Membership;
        public string Phone;
        public string JoinDate;
        public string ExpiredDate;
        public string ProfileURI;
        public MemberResponse(int? Id ,string Name , string Phone ,string Membership ,  string JoinDate , string ExpiredDate, string ProfileURI ) {
            
            this.Id = Id;
            this.Name = Name;
            this.Phone = Phone;
            this.Membership = Membership;
            this.JoinDate = JoinDate;
            this.ExpiredDate = ExpiredDate;
            this.ProfileURI  = ProfileURI;
        }
    }
}
