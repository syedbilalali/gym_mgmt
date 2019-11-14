using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gym_mgmt_01.BAL.Master;
using gym_mgmt_01.Models;

namespace gym_mgmt_01.Controllers
{
    public class TrainingController : Controller
    {
        ClassesOpt classOpt = new ClassesOpt();
        // GET: Training
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection fc)
        {   

            fc[""];
            Classes cl = new Classes();
            cl.ClassName = fc["ClassName"].ToString();
            cl.From = fc["From"].ToString();
            classOpt.AddClasses();
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