using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.IO;
using gym_mgmt_01.BAL.Master;
using gym_mgmt_01.Models;
using System.Configuration;

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
        public ActionResult Index(FormCollection  fc , HttpPostedFileBase ImageFile) {
           
            Staff st = new Staff();
            st.FirstName = fc["firstName"];
            st.LastName = fc["lastName"];
            st.Email = fc["email"];
            st.Gender = fc["gender"];
            st.Password = fc["password"];
            st.Designation = fc["designation"];
            string path = uploadFile(ImageFile);
            st.ImgURL =  path;
         //   Response.Write("Staff Data : " + st.FirstName + " Designation " + st.Designation);
           so.AddStaff(st);
            return View();
        }
        public ActionResult Authorize() {
            return View();
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
        public ActionResult FindStaff() {
            return View();
        }
        string fullPath;
        string relativePath;
        private string uploadFile(HttpPostedFileBase file)
        {
            string trailingPath;
            if (file != null)
            {
                if (file.ContentType == "image/jpeg")
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
                }

            }
            else
            {
                relativePath = "/assets/images/users/user4.png";

            }
            return relativePath;
        }
    }
}