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
        MemberOperation memOpt = new MemberOperation();
        StaffOperation staffOp = new StaffOperation();
        dynamic model = new System.Dynamic.ExpandoObject();
        // GET: Training
        public ActionResult Index()
        {
            List<Classes> cl = classOpt.getAllClasses();
            List<Staff> st = staffOp.getAllStaff();
            model.classes = cl;
            model.staff = st;
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
            List<Member> memlist = memOpt.getAllMembers();
            List<Classes> classlist = classOpt.getAllClasses();
            model.classSubs = list;
            model.members = memlist;
            model.classlist = classlist;
            return View(model);
        }
        public JsonResult getSubscriptionByID(int? id)
        {
            List<ClassSubscriptions> list = classOpt.getAllClassSubs();
            var cls = list.Find(x => x.Id.Equals(id));
            return Json(cls, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult updateSubscription(FormCollection fc) {
            int subsCriptionID = int.Parse(fc["Id"].ToString());
            int memberID = int.Parse(fc["memberudt"].ToString());
            int classID = int.Parse(fc["classudt"].ToString());
            classOpt.updateClassSubscription(subsCriptionID , memberID , classID); 
            return RedirectToAction("AssignClass");
        }
        public JsonResult getClasses(int id) {
            List<Classes> classes = classOpt.getAllClasses();
            var data = classes.Find(x => x.Id.Equals(id));
            data.From = DateTime.Parse(data.From.ToString("hh:mm tt"));
            data.To = DateTime.Parse(data.To.ToString("hh:mm tt"));
            return Json(data , JsonRequestBehavior.AllowGet);
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
        public ActionResult addClassSubscriptions(FormCollection fc) {
            
            if (ModelState.IsValid) {

                int classID = int.Parse(fc["class"].ToString());
                int memberID = int.Parse(fc["member"].ToString());

                ClassSubscriptions cs = new ClassSubscriptions();
                cs.ClassID = classID;
                cs.MemberID = memberID;
                classOpt.AddClassSubscriptions(cs);
            }
            return RedirectToAction("AssignClass");
        }
        public ActionResult editClasssSubscriptions(FormCollection fc) {
            return View();
        }
    }
}