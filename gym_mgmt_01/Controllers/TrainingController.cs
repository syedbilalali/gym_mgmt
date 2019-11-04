using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gym_mgmt_01.Controllers
{
    public class TrainingController : Controller
    {
        // GET: Training
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AssignClass() {
            return View();
        }
        public ActionResult AddReminder() {
            return View();
        }
    }
}