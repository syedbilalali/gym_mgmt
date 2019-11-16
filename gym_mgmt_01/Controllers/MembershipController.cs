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
                mem.ValidDays = int.Parse(fc["ValidDays"].ToString());
                mem.Amount = decimal.Parse(fc["Amount"].ToString());
                mem.StartDate = DateTime.Parse(fc["StartDate"].ToString());
                mem.EndDate = DateTime.Parse(fc["EndDate"].ToString());
                mem.PreEndDate = DateTime.Parse(fc["PreEndDate"].ToString());
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
    }
}