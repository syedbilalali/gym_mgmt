using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gym_mgmt_01.BAL.Master;
using gym_mgmt_01.Models;
using gym_mgmt_01.Helper_Code.Common;

namespace gym_mgmt_01.Controllers
{
    public class TrainingController : Controller
    {
        ClassesOpt classOpt = new ClassesOpt();
        MemberOperation memOpt = new MemberOperation();
        StaffOperation staffOp = new StaffOperation();
        dynamic model = new System.Dynamic.ExpandoObject();

        // GET: Training
        [AuthorizationPrivilegeFilter("Training Schedule" , "View")]
        public ActionResult Index()
        {
            if (Session["modules"] != null)
            {
                List<ModuleDetails> md = Session["modules"] as List<ModuleDetails>;
                ModuleDetails md1 = md.Find(x => x.Module.Equals("Training Schedule"));
                ViewBag.Module = md1.Module;
                ViewBag.Create = md1.Create;
                ViewBag.Edit = md1.Edit;
                ViewBag.Delete = md1.Delete;
            }
            List<Classes> cl = classOpt.getAllClasses();
            List<Staff> st = staffOp.getAllStaff();
            model.classes = cl;
            model.staff = st;
            TempData["stafflist"] = getList(st);
            return View(model);
        }
        [HttpPost]
        [AuthorizationPrivilegeFilter("Training Schedule", "Create")]
        public ActionResult Index(FormCollection fc)
        {   
            Classes cl = new Classes();
            cl.ClassName = fc["ClassName"].ToString();
            string fromTime = fc["From"].ToString();
            string to = fc["To"].ToString();
            cl.From = DateTime.Parse( fromTime, System.Globalization.CultureInfo.CurrentCulture);
           // cl.From = DateTime.Parse(fc["From"].ToString());
            cl.To = DateTime.Parse(to, System.Globalization.CultureInfo.CurrentCulture);
            cl.Note = fc["Note"].ToString();
            cl.Repeats = fc["Repeats"].ToString();
            cl.RepeatsEnd = DateTime.Parse(fc["RepeatsEnd"].ToString());
            cl.Resource = fc["Resource"].ToString();
            cl.StaffID = int.Parse(fc["StaffID"].ToString());
            classOpt.AddClasses(cl);
            return RedirectToAction("Index");
        }

        [AuthorizationPrivilegeFilter("Training Schedule", "View")]
        public ActionResult AssignClass() {

            if (Session["modules"] != null)
            {
                List<ModuleDetails> md = Session["modules"] as List<ModuleDetails>;
                ModuleDetails md1 = md.Find(x => x.Module.Equals("Training Schedule"));
                ViewBag.Module = md1.Module;
                ViewBag.Create = md1.Create;
                ViewBag.Edit = md1.Edit;
                ViewBag.Delete = md1.Delete;
            }
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
        [AuthorizationPrivilegeFilter("Training Schedule", "Edit")]
        public ActionResult updateSubscription(FormCollection fc) {
            int subsCriptionID = int.Parse(fc["Id"].ToString());
            int classID = int.Parse(fc["classudt"].ToString());
            classOpt.updateClassSubscription(subsCriptionID, classID); 
            return RedirectToAction("AssignClass");
        }
        public JsonResult getClasses(int id) {
            List<Classes> classes = classOpt.getAllClasses();
            var data = classes.Find(x => x.Id.Equals(id));
            //     data.From = DateTime.Parse(data.From.ToString("hh:mm tt"));
            //    data.To = DateTime.Parse(data.To.ToString("hh:mm tt"));
            return Json(data , JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddReminder() {
            return View();
        }

        [AuthorizationPrivilegeFilter("Training Schedule", "Delete")]
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
        [AuthorizationPrivilegeFilter("Training Schedule", "Create")]
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

        [AuthorizationPrivilegeFilter("Training Schedule", "Edit")]
        public ActionResult EditClass1(FormCollection fc) {
            if (ModelState.IsValid) {
                Classes cl = new Classes();
                cl.Id = int.Parse(fc["classID"].ToString());
                cl.ClassName = fc["className"].ToString();
                cl.From = DateTime.Parse(fc["From"].ToString());
                cl.To = DateTime.Parse(fc["To"].ToString());
                cl.Note = fc["Note"].ToString();
                cl.Repeats = fc["Repeats"].ToString();
                cl.RepeatsEnd = DateTime.Parse(fc["RepeatsEnd"].ToString());
                cl.Resource = fc["Resource"].ToString();
                cl.StaffID = int.Parse(fc["ClassName"].ToString());
                classOpt.UpdateClass(cl);
                
            }
            return RedirectToAction("Index");
        }
        [AuthorizationPrivilegeFilter("Training Schedule", "Edit")]
        public ActionResult _EditClass1(Classes cl) {
            if (ModelState.IsValid) {
                classOpt.UpdateClass(cl);
            }
            List<Staff> st = staffOp.getAllStaff();
            TempData["stafflist"] = getList(st);
            return RedirectToAction("Index");
          //  return PartialView(new gym_mgmt_01.Models.Classes());
        }
        public List<SelectListItem> getList(List<Staff> st) {
            List<SelectListItem> staff = new List<SelectListItem>();
            staff.Add(new SelectListItem() { Text="--SELECT STAFF--" , Value=""});
            foreach (var s in st) {
                staff.Add(new SelectListItem()
                {
                    Text = s.FirstName,
                    Value = s.StaffID
                });
            }
            return staff;
        }
        [HttpPost]
        public JsonResult checkdata(Classes cl)
        {
            
            return Json(false);

        }
    }
}