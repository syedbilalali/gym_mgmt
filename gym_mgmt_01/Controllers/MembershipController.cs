using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gym_mgmt_01.Models;
using gym_mgmt_01.BAL.Master;
using gym_mgmt_01.Helper_Code.Common;

namespace gym_mgmt_01.Controllers
{
    public class MembershipController : Controller
    {
        // GET: Membership
        MembershipOpt memOpt = new MembershipOpt();
        MemberOperation mOpt = new MemberOperation();
        SubscriptionOpt subs = new SubscriptionOpt();
        dynamic model = new System.Dynamic.ExpandoObject();

        [AuthorizationPrivilegeFilter("Membership" , "View")]
        public ActionResult Index()
        {
            if (Session["modules"] != null)
            {
                List<ModuleDetails> md = Session["modules"] as List<ModuleDetails>;
                ModuleDetails md1 = md.Find(x => x.Module.Equals("Membership"));
                ViewBag.Create = md1.Create;
            }
            return View();
        }
        [HttpPost]
        [AuthorizationPrivilegeFilter("Membership", "Create")]
        public ActionResult Index(Membership mem) {

            if (ModelState.IsValid) {

                int subtractingDays = int.Parse(mem.PreExpirationDays.ToString());
                mem.ValidDays = subtractingDays;
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
        [AuthorizationPrivilegeFilter("Membership", "View")]
        public ActionResult ViewMemberships()
        {
            if (Session["modules"] != null)
            {
                List<ModuleDetails> md = Session["modules"] as List<ModuleDetails>;
                ModuleDetails md1 = md.Find(x => x.Module.Equals("Membership"));
                ViewBag.Create = md1.Create;
                ViewBag.Edit = md1.Edit;
                ViewBag.Delete = md1.Delete;
            }
            List<Membership> data = memOpt.getAllMembership();
            model.membership = data;
            return View(model);
        }
        [AuthorizationPrivilegeFilter("Membership", "Delete")]
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
        [AuthorizationPrivilegeFilter("Membership", "View")]
        public ActionResult Subscriptions() {


            if (Session["modules"] != null)
            {
                List<ModuleDetails> md = Session["modules"] as List<ModuleDetails>;
                ModuleDetails md1 = md.Find(x => x.Module.Equals("Membership"));
                ViewBag.Create = md1.Create;
                ViewBag.Edit = md1.Edit;
                ViewBag.Delete = md1.Delete;
            }
            List<Member> memdata = mOpt.getAllMembers();
            List<Membership> mshOpt = memOpt.getAllMembership();
            List<Subscriptions> sub1 = subs.getAllSubscriptions();
            model.member = memdata;
            model.membrshp = mshOpt;
            model.subscription = sub1; 
            return View(model);
        }
        [AuthorizationPrivilegeFilter("Membership", "Create")]
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

            List<Subscriptions> sb = subs.getAllSubscriptions();
            var prod = sb.Find(x => x.Id.Equals(id));
            return Json(prod, JsonRequestBehavior.AllowGet);
        }
        [AuthorizationPrivilegeFilter("Membership", "Edit")]
        public ActionResult editSubscription(FormCollection fc) {

            int Id = int.Parse(fc["subID"].ToString());
            int membershipID = int.Parse(fc["membership"]);
            Subscriptions sb = new Subscriptions();
            sb.Id = Id;
            sb.MembershipID = membershipID;
            bool flag = subs.UpdateSubscriptions(sb);
            if (flag)
            {
                ViewBag.Message = "Membership Updated Successfully";
            }
            else {
                ViewBag.Message = "Something went wrong !!! ";
            }
            return RedirectToAction("Subscriptions");
        }
        [AuthorizationPrivilegeFilter("Membership", "Delete")]
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
        [AuthorizationPrivilegeFilter("Membership", "Edit")]
        public ActionResult editMembership(Membership mem)
        {
            if (ModelState.IsValid)
            {
                int subtractingDays = int.Parse(mem.PreExpirationDays.ToString());
                mem.ValidDays = subtractingDays;
                mem.PreEndDate = mem.EndDate.Subtract(TimeSpan.FromDays(subtractingDays));
                bool flag = memOpt.UpdateMembership(mem);
                if (flag)
                {
                    ViewBag.Message = " Successfully Add Membership !!! ";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.Message = " Something Went Wrong !!! ";
                }
            }
            return RedirectToAction("ViewMemberships");
        }
        [HttpPost]
        public JsonResult CheckStartDate(Membership mem)
        {
            return Json(IsStartDateAvailable(mem));
        }
        public bool IsStartDateAvailable(Membership mem)
        {
            bool status;
            if (DateTime.Compare(mem.StartDate , mem.EndDate) < 0)
            {
                status = false;
            }
            else
            {
                status = true;
            }
            return status;
        }
        [HttpPost]
        public JsonResult CheckEndDate(Membership mem) {
            return Json(IsEndDateAvailable(mem));
        }
        public bool IsEndDateAvailable(Membership mem) {
            bool status;
            if (DateTime.Compare(mem.StartDate, mem.EndDate) > 1)
            {
                status = false;
            }
            else
            {
                status = true;
            }
            return status;
        }
        public ActionResult _AddSubscriptions() {
            List<Member> memdata = mOpt.getAllMembers();
            List<Membership> mshOpt = memOpt.getAllMembership();
            memdata.Select(i => new SelectListItem()
                           {
                             Text = i.FirstName,
                             Value = i.Id.ToString()
            });
            mshOpt.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString() 
            }) ;
            ViewBag.Member = memdata;
            ViewBag.Membership = mshOpt;
           return View();
        }


    }
}