using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using gym_mgmt_01.BAL.Master;

namespace gym_mgmt_01.Controllers
 {
    [Authorize]
    public class StaffController : Controller
    {
        StaffOperation so = new StaffOperation();
        // GET: Staff
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection  fc) {
            

            return View();
        }
        public ActionResult Authorize() {
            return View();
        }
        public ActionResult FindStaff() {
            return View();
        }
    }
}