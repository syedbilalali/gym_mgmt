﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net;
using System.Net.Http;
using System.Web;
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
        StaffOperation so = new StaffOperation();
        [HttpGet, AllowAnonymous, Route("loginA")]
        public HttpResponseMessage Get()
        {
            //   Emp e = new Emp("bilal" , "123");
            return Request.CreateResponse(HttpStatusCode.OK, new Message(HttpStatusCode.OK, "Login Successfully", "success"));
        }
        [HttpPost, AllowAnonymous, Route("login")]
        public HttpResponseMessage GetCheckIn(HttpRequestMessage req)
        {
            string data = req.Content.ReadAsStringAsync().Result;
            string[] array = data.Split('&');
            string[] userkeyValue = array[0].Split('=');
            string[] rolekeyValue = array[1].Split('=');
            string userid = userkeyValue[1];
            string role = rolekeyValue[1];
            try
            {
                if (userid != null && role != null)
                {
                    if (role.ToUpper() == "MEMBER")
                    {
                        Member mem = mo.getMember(int.Parse(userid));
                        Contact con = co.GetContact(int.Parse(userid));
                        if (mem != null && mem.Id != null && mem.Id != 0)
                        {

                            Subscriptions sbs = sub.getSubscriptionByMemberID(mem.Id);
                            MembershipOpt mo = new MembershipOpt();
                            if (sbs != null && sbs.Id != 0)
                            {
                                Membership mbr = mo.getMembershipByID(sbs.MembershipID);
                                TimeSpan timeSpan = mbr.EndDate - DateTime.Now;
                                TimeSpan timeSpan1 = mbr.StartDate - DateTime.Now;
                                if (timeSpan1.Days > 0)
                                {
                                    return Request.CreateResponse(HttpStatusCode.OK, new Message("Membership Not Started"));
                                }
                                else if (timeSpan.Days >= 0)
                                {

                                    var url = req.RequestUri.GetLeftPart(UriPartial.Authority);
                                    MemberResponse mr = new MemberResponse(mem.Id, mem.FirstName + " " + mem.LastName, con.Cell, mbr.Name, mbr.StartDate.ToShortDateString(), mbr.EndDate.ToShortDateString(), url + mem.ImagePath, "Verified");
                                    Visitor visit = new Visitor();
                                    visit.UserID = int.Parse(mem.Id.ToString());
                                    visit.UserType = "Member";
                                    visit.VisitorName = mr.Name;
                                    visit.Date = DateTime.Today.ToShortDateString();
                                    visit.Clock = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                                    visit.Status = "";
                                    vo.AddVisit(visit);
                                    return Request.CreateResponse(HttpStatusCode.OK, mr);
                                }
                                else
                                {
                                    return Request.CreateResponse(HttpStatusCode.OK, new Message("Membership Expired"));
                                }

                            }
                            else
                            {
                                return Request.CreateResponse(HttpStatusCode.OK, new Message("Membership Not Found"));
                            }
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, new Message("Userid Not Found"));
                        }

                    }
                    else 
                    {
                        Staff st = so.getStaffByID(userid);
                        if (st != null)
                        {
                            var url = req.RequestUri.GetLeftPart(UriPartial.Authority);
                            StaffResponse staff = new StaffResponse(st.FirstName + ' ' + st.LastName, st.Designation, st.Email, url + st.ImgURL, "Staff");
                            Visitor visit = new Visitor();
                            visit.UserID = int.Parse(st.StaffID.ToString());
                            visit.UserType = "Staff";
                            visit.VisitorName = staff.Name;
                            visit.Date = DateTime.Today.ToShortDateString();
                            visit.Clock = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                            visit.Status = "";
                            vo.AddVisit(visit);
                            return Request.CreateResponse(HttpStatusCode.OK, staff);
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, new Message("Staff Not Found"));
                        }
                    }
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new Message("Userid Required"));
                }
            }
            catch (Exception e)
            {

                return Request.CreateErrorResponse(HttpStatusCode.OK, "Please Contact to Server Adminstrator !!! ");
            }
        }
    }
}
