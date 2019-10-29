using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.IO;
using System.Web.Mvc;
using gym_mgmt_01.BAL.Master;
using gym_mgmt_01.Models;

namespace gym_mgmt_01.Controllers
{   
    [Authorize]
    public class MemberController : Controller
    {
        // GET: Member
        MemberOperation mo = new MemberOperation();
        ContactOpration co = new ContactOpration();
        EmergencyContactOpt eco = new EmergencyContactOpt();
        AddtionalDetailsOpt ado = new AddtionalDetailsOpt();
        PropectusOperation po = new PropectusOperation();
        public ActionResult Index()
        {
            ViewBag.ID = mo.getMemberID();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection fc , HttpPostedFileBase ImageFile) {
            if (ModelState.IsValid) {

                    Member m1 = new Member();
                    m1.FirstName = fc["FirstName"];
                    m1.LastName = fc["LastName"];   
                    m1.DOB = fc["dob"];
                    m1.Gender = fc["gender"];
                    m1.note = fc["note"];
                    m1.MemberType = fc["memberType"];
                    string path=uploadFile(ImageFile);
                    m1.ImagePath = path;
                    mo.AddMemeber(m1);
            }
            return View();
        }
        public ActionResult Hello(FormCollection fc) {
            if (ModelState.IsValid)
            {

              //  Response.Write(" Image Address " + mb.ImageFile);
                //Add Member Details....
                // Response.Write(" First Name" + mb.FirstName );
                //  Response.Write(" Last Name " +mb.LastName );
                // Response.Write(" Member Type : " +mb.MemberType );
                // Response.Write(" Date of Brith" + mb.DOB );

                // string memberTypeCheck = fc["memberType"];
                //  Member m1 = new Member();
                ///  m1.FirstName = fc["FirstName"];
                //    m1.LastName = fc["LastName"];   
                //    m1.DOB = fc["dob"];
                //    m1.Gender = fc["gender"];
                //    m1.note = fc["note"];
                //    m1.MemberType = "";
                //    m1.ImagePath   = "";
              //  string path = uploadFile(file);
                //    string formID = mo.getMemberID();
                //    mo.AddMemeber(m1);
              //  Response.Write(" File Path : " + path);

            }
            return View();
        }
        public ActionResult FindMember() {
            return View();
        }
        string fullPath;
        string relativePath;
        private string uploadFile(HttpPostedFileBase file) {
            string trailingPath;
            if (file != null)
            {
                if (file.ContentType == "image/jpeg")
                {
                    if (file.ContentLength < 102400) {

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
            else {
               
            }
            return relativePath;
        }

    }
}