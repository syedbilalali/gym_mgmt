using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.IO;
using System.Reflection;
using gym_mgmt_01.BAL.Master;
using gym_mgmt_01.Models;
using System.Configuration;
using Newtonsoft.Json;
using gym_mgmt_01.Helper_Code.Common;

namespace gym_mgmt_01.Controllers
 {
    [Authorize]
    public class StaffController : Controller
    {
        StaffOperation so = new StaffOperation();
        RoleOperation ro = new RoleOperation();
        dynamic model = new System.Dynamic.ExpandoObject();




        // GET: Staff
        [AuthorizationPrivilegeFilter("Staff", "Create")]
        public ActionResult Index()
        {
            if (Session["modules"] != null) {
                List<ModuleDetails> md = Session["modules"] as List<ModuleDetails>;
                ModuleDetails md1 = md.Find(x => x.Module.Equals("Staff"));
                ViewBag.Module = md1.Module;
                ViewBag.Create = md1.Create;
                ViewBag.Edit = md1.Edit;
                ViewBag.Delete = md1.Delete;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizationPrivilegeFilter("Staff" , "View")]
        public ActionResult Index(Staff st) {

            if(ViewBag.Create != false) {
                string path = uploadFile(st.PostedFile);
                if (ModelState.IsValid)
                {
                    st.ImgURL = path;
                    st.permission = getDefaultPermission();
                    so.AddStaff(st);
                    ViewBag.result = "yes";
                    ModelState.Clear();
                    ViewBag.Message = " Staff Member added successfully !!! ";
                }
            }
            else
            {
                ViewBag.Message = "You are not authorise to add staff.";
            }
           return View();
        }
        public string getDefaultPermission() {

            RoleOperation ro = new RoleOperation();
            List<Role>  data = ro.getRoles();
            ModuleDetails md = new ModuleDetails();
            List<ModuleDetails> det = new List<ModuleDetails>();
            foreach (var d in data) {
                det.Add(new ModuleDetails { Module = d.Roles, status = "off" });
            }
            string js = JsonConvert.SerializeObject(det);
            return js;
        }
        public ActionResult Authorize(int id)
        {
            List<Staff> staffs = so.getAllStaff();
            TempData["Id"] = id.ToString();
            Staff st = staffs.Find(x => x.StaffID.Contains(id.ToString()));
            List<ModuleDetails> md = JsonConvert.DeserializeObject<List<ModuleDetails>>(st.permission);
            return View(md);
        }
        [HttpGet]
        public JsonResult getStaff() {
            DataTable dt = new DataTable();
            dt = so.geAllStaff();
            List<Staff> data = new List<Staff>();
            data = (from DataRow dr in dt.Rows
                    select new Staff()
                    {
                        StaffID = dr["StaffID"].ToString(),
                        FirstName = dr["FirstName"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        Gender = dr["Gender"].ToString(),
                        Email = dr["Email"].ToString(),
                        Designation = dr["Designation"].ToString(),
                        ImgURL = dr["ImgURL"].ToString()
                    }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
         }
        [AuthorizationPrivilegeFilter("Staff" ,"View" )]
        public ActionResult FindStaff() {
            if (Session["modules"] != null)
            {
                List<ModuleDetails> md = Session["modules"] as List<ModuleDetails>;
                ModuleDetails md1 = md.Find(x => x.Module.Equals("Staff"));
                ViewBag.Module = md1.Module;
                ViewBag.Create = md1.Create;
                ViewBag.Edit = md1.Edit;
                ViewBag.Delete = md1.Delete;
            }
            DataTable dt = new DataTable();
            dt = so.geAllStaff();
            List<Staff> data = new List<Staff>();
            data = (from DataRow dr in dt.Rows
                    select new Staff()
                    {
                        StaffID = dr["StaffID"].ToString(),
                        FirstName = dr["FirstName"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        Gender = dr["Gender"].ToString(),
                        Email = dr["Email"].ToString(),
                        Designation = dr["Designation"].ToString(),
                        ImgURL = dr["ImgURL"].ToString()
                    }).ToList();
            model.staff = data;
            return View(model);
        }
        [HttpPost]
        public ActionResult SetAuth(List<ModuleDetails> md)
        {
            string Id = TempData["id"].ToString();
            so.updatePermission(JsonConvert.SerializeObject(md), Id);
            return RedirectToAction("Authorize", new { id = Id });
        }
        
        public JsonResult StaffEdit(int id) {
            
            List<Staff> staff = so.getAllStaff();
            var st = staff.Find(x => x.StaffID.Equals(id.ToString()));
            return Json(st, JsonRequestBehavior.AllowGet);
        }
        [AuthorizationPrivilegeFilter("Staff", "Edit")]
        public ActionResult _EditStaff(Staff  st) {

            if (ModelState.IsValid) {
                if (st.PostedFile != null)
                {
                    st.ImgURL = uploadFile(st.PostedFile);
                    so.updateStaff(st);
                }
                else {
                    so.updateStaff(st);
                }
              
            }
           return RedirectToAction("FindStaff");
        }
        [AuthorizationPrivilegeFilter("Staff" , "Delete")]
        public ActionResult DeleteStaff(int id)
        {
            try
            {
                bool result = so.deleteStaffByID(id);
                if (result == true)
                {
                    ViewBag.Message = "Staff Member Deleted Successfully";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.Message = " Sorry Something went Wrong !!! ";
                    ModelState.Clear();
                }
                return RedirectToAction("FindStaff");
            }
            catch
            {
                throw;
            }
        }
        string fullPath;
        string relativePath;
        private string uploadFile(HttpPostedFileBase file)
        {
            string trailingPath;
            if (file != null)
            {
                if (file.ContentType == "image/jpeg" || file.ContentType == "image/gif" || file.ContentType == "image/png")
                {
                    if (file.ContentLength < 102400)
                    {

                        string FileName = Path.GetFileNameWithoutExtension(file.FileName);
                        //To Get File Extension  
                        string FileExtension = Path.GetExtension(file.FileName);

                        //Add Current Date To Attached File Name  
                        FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;

                        //Get Upload path from Web.Config file AppSettings.  
                        string UploadPath = ConfigurationManager.AppSettings["UserImagePath"].ToString();

                        //Its Create complete path to store in server.  
                        //  string ImagePath = UploadPath + FileName;
                        trailingPath = Path.GetFileName(file.FileName);
                        fullPath = Path.Combine(Server.MapPath("~/assets/images/users/"), trailingPath);
                        relativePath = "/assets/images/users/" + trailingPath;
                        //To copy and save file into server.  
                        file.SaveAs(fullPath);
                    }
                    else
                    {
                        ModelState.AddModelError("m.PostedFile", "Please upload image less then 100 MB ");
                       ViewBag.Message = "";
                    }
                }
                else
                {
                    ModelState.AddModelError("m.PostedFile", " Image formate not supportted ");
                   ViewBag.Message = "";
                }
            }
            else
            {
                relativePath = "/assets/images/users/deafult.png";
            }
            return relativePath;
        }
        [HttpPost]
        public JsonResult IsAlreadyEmail(Staff st)
        {
            return Json(IsEmailAvailable(st.Email));
        }
        public bool IsEmailAvailable(string email)
        {
            List<Staff> data = so.getAllStaff();
            var gn = (from u in data
                      where u.Email.ToUpper() == email.ToUpper()
                      select new { email }).FirstOrDefault();
            bool status;
            if (gn != null)
            {
                status = false;
            }
            else
            {
                status = true;
            }
            return status;
        }
    }
   
}