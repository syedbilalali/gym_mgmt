using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using gym_mgmt_01.BAL.Master;
using gym_mgmt_01.Models;

namespace gym_mgmt_01.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role
        RoleOperation ro = new RoleOperation();
        dynamic model = new System.Dynamic.ExpandoObject();
        public ActionResult Index()
        {
            List<RoleGroup> rg = ro.getAllRoleGroup();
            ViewData["rolegroup"] = rg;
            return View();
        }
        public ActionResult addRoleGroup(RoleGroup rg) {
            if (ModelState.IsValid) {
                ro.AddRoleGroup(rg);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult IsAlreadyGroup(string groupname)
        {

            return Json(IsgGroupAvailable(groupname));
        }
        public bool IsgGroupAvailable(string groupname) {
            List<RoleGroup> data = ro.getAllRoleGroup();
            var gn = (from u in data
                              where u.GroupName.ToUpper() == groupname.ToUpper()
                              select new { groupname }).FirstOrDefault();
            bool status;
            if (gn != null) 
            {
                status = false;
            } else {
                status = true;
            }
            return status;
        }
    }
}