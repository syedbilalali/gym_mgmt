﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gym_mgmt_01.Models;
using gym_mgmt_01.BAL.Master;

namespace gym_mgmt_01.Controllers
{
    public class MembershipController : Controller
    {
        // GET: Membership
        MembershipOpt memOpt = new MembershipOpt();
        MemberOperation mOpt = new MemberOperation();
        SubscriptionOpt subs = new SubscriptionOpt();
        dynamic model = new System.Dynamic.ExpandoObject();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Membership mem) {

        //    Membership mem = new Membership();
            if (ModelState.IsValid) {
                 
                 int subtractingDays = int.Parse(mem.PreExpirationDays.ToString());
                 mem.PreEndDate = mem.EndDate.Subtract(TimeSpan.FromDays(subtractingDays));
                bool flag =  memOpt.AddMembership(mem);
                if (flag)
                {
                    ViewBag.Message = " Successfully Add Membership !!! ";
                    ModelState.Clear();
                }
                else {
                    ViewBag.Message = " Something Went Wrong !!! ";
                }
            }
            return View();
        }
        public ActionResult ViewMemberships()
        {
            List<Membership> data = memOpt.getAllMembership();
            model.membership = data;
            return View(model);
        }
        public ActionResult DeleteMembership(int id)
        {
            try
            {
                bool result = memOpt.deleteMembership(id) ;
                if (result == true)
                {
                    ViewBag.Message = "Customer Deleted Successfully";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.Message = "Unsucessfull";
                    ModelState.Clear();
                }

                return RedirectToAction("ViewMemberships");
            }
            catch
            {
                throw;
            }
        }
        public ActionResult Subscriptions() {
          
            List<Member> memdata = mOpt.getAllMembers();
            List<Membership> mshOpt = memOpt.getAllMembership();
            List<Subscriptions> sub1 = subs.getAllSubscriptions();
            model.member = memdata;
            model.membrshp = mshOpt;
            model.subscription = sub1; 
            return View(model);
        }
        public ActionResult addSubscriptions(FormCollection fc) {
            
            if (ModelState.IsValid) {
                Subscriptions sop = new Subscriptions();
                sop.MembershipID = int.Parse(fc["membershp"].ToString());
                sop.MemberID = int.Parse(fc["member"].ToString());
                subs.AddSubscriptions(sop);
            }
            return RedirectToAction("Subscriptions");
        }
        public JsonResult getMemberships(int id)
        {
            List<Membership> mshOpt = memOpt.getAllMemberships();
            var prod = mshOpt.Find(x => x.Id.Equals(id));
            if (prod == null)
            {
                return Json(" No Result Found !!! ", JsonRequestBehavior.AllowGet);
            }
            return Json(prod, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getSubscription(int id) {

            List<Membership> mshOpt = memOpt.getAllMembership();
            var prod = mshOpt.Find(x => x.Id.Equals(id));
            return Json(prod, JsonRequestBehavior.AllowGet);
        }
        public ActionResult deleteSubscriptions(int id)
        {
            try
            {
                bool result = subs.DeleteSubscriptions(id);
                if (result == true)
                {
                    ViewBag.Message = "Customer Deleted Successfully";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.Message = "Unsucessfull";
                    ModelState.Clear();
                }
                return RedirectToAction("Subscriptions");
            }
            catch
            {
                throw;
            }
        }
        [HttpPost]
        public ActionResult editSubscription(FormCollection fc)
        {
            int MemberID = int.Parse(fc["member"].ToString());
            int MembershipID = int.Parse(fc["membershp"].ToString());
            //  subs.UpdateSubscriptions(MemberID , MembershipID);
            return RedirectToAction("ViewMemberships");
        }
    }
}