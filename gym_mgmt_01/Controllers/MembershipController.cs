using System;
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
        public ActionResult Index(FormCollection fc) {

            Membership mem = new Membership();
            if (ModelState.IsValid) {
                mem.Name = fc["Name"].ToString();
                mem.Description = fc["Description"].ToString();
                // mem.ValidDays = int.Parse(fc["ValidDays"].ToString());
                mem.ValidDays = 0;
                mem.Amount = decimal.Parse(fc["Amount"].ToString());
                mem.StartDate = DateTime.Parse(fc["StartDate"].ToString());
                mem.EndDate = DateTime.Parse(fc["EndDate"].ToString());
                int subtractingDays = int.Parse(fc["PreExpDays"].ToString());
                mem.PreEndDate = mem.EndDate.Subtract(TimeSpan.FromDays(subtractingDays));
                mem.Capacity = int.Parse(fc["Capacity"].ToString());
                bool flag =  memOpt.AddMembership(mem);
                if (flag)
                {
                    ViewBag.Message = " Successfully Add Membership !!! ";
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

            int MemberID = int.Parse(fc["memberID"].ToString());
            int MembershipID = int.Parse(fc["membershipID"].ToString());
            //  subs.UpdateSubscriptions(MemberID , MembershipID);
            return RedirectToAction("Index");
        }
    }
}