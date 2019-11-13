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
            List<RoleGroup> role = ro.getAllRoleGroup();
            ViewData["RoleGroup"] = role;
            model.roleGroup = role;
            return View(model);
        }
    }
}