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
        dynamic model = new System.Dynamic.ExpandoObject();
        // GET: Training
        public ActionResult Index()
        {
            List<Classes> cl = classOpt.getAllClasses();
            model.classes = cl; 
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(FormCollection fc)
        {   
            Classes cl = new Classes();
            cl.ClassName = fc["ClassName"].ToString();
            cl.From = DateTime.Parse(fc["From"].ToString());
            cl.To = DateTime.Parse(fc["To"].ToString());
            cl.Note = fc["Note"].ToString();
            cl.Repeats = fc["Repeats"].ToString();
            cl.RepeatsEnd = DateTime.Parse(fc["RepeatsEnd"].ToString());
            cl.Resource = fc["Resource"].ToString();
            cl.StaffID = int.Parse(fc["StaffID"].ToString());
            classOpt.AddClasses(cl);
            return RedirectToAction("Index");
        }
        public ActionResult AssignClass() {
            List<ClassSubscriptions> list = classOpt.getAllClassSubs();
            model.classSubs = list;
            return View(model);
        }
        public ActionResult AddReminder() {
            return View();
        
        }
        public ActionResult DeleteClasses(int id)
        {
            try
            {
                bool result = classOpt.deleteClassbyID(id);
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
                return RedirectToAction("Index");
            }
            catch
            {
                throw;
            }
        }
    }
}