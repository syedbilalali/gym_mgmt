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
            List<Role> role = ro.getAllRole();
            List<RoleGroup> roleGroup = ro.getAllRoleGroup();
            ViewData["Role"] = role;
            model.roleGroup = roleGroup;
            return View(model);
        }
        public ActionResult addRoleGroup(FormCollection fc) {
            return RedirectToAction("Index");
        }
    }
}