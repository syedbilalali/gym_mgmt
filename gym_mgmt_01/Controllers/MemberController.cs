using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.IO;
using System.Web.Mvc;
using gym_mgmt_01.BAL.Master;
using gym_mgmt_01.Models;
using System.Data;
using System.Reflection;
using gym_mgmt_01.Helper_Code.Common;

namespace gym_mgmt_01.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        // GET: Member
        MemberOperation mo = new MemberOperation();
        ContactOpration co = new ContactOpration();
        MembershipOpt memOpt = new MembershipOpt();
        SubscriptionOpt so = new SubscriptionOpt();
        DataTable dt = new DataTable();
        dynamic model = new System.Dynamic.ExpandoObject();


        [AuthorizationPrivilegeFilter("Find Member", "View")]
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                if (Session["modules"] != null) {
                    List<ModuleDetails> md = Session["modules"] as List<ModuleDetails>;
                    ModuleDetails  md1 =  md.Find(x => x.Module.Equals("Member"));
                    ViewBag.Create = md1.Create;
                    ViewBag.Edit = md1.Edit;
                    ViewBag.Delete = md1.Delete;
                }
                ViewBag.ID = mo.getMemberID();
                MemberRegistration mr = new MemberRegistration();
                mr.member = new Member();
                mr.contact = new Contact() { Id = int.Parse(mo.getMemberID()) };
                ViewBag.Alert = "none";
                ViewBag.Message = "";
                return View(mr);
            } else {
            
                Member mem = mo.getMember(id);
                ViewBag.ID = mem.Id;
                model.data = mem;
                ViewBag.Alert = "none";
                return View(mem);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizationPrivilegeFilter("Member", "Create")]
        public ActionResult Index([Bind(Exclude = "Id")] MemberRegistration mr) {
            var validImageTypes = new string[]
            {
                "image/gif",
                "image/jpeg",
                "image/pjpeg",
                "image/png"
            };
            if (mr.ImageFile == null || mr.ImageFile.ContentLength == 0)
            {
               // ModelState.AddModelError("ImageUpload", "This field is required");
            }
            else if (!validImageTypes.Contains(mr.ImageFile.ContentType))
            {
              //  ModelState.AddModelError("ImageUpload", "Please choose either a GIF, JPG or PNG image.");
            }
            mr.member.ImagePath = uploadFile(mr.ImageFile);
            //mr.member.ImagePath = SaveSnap(Request.Form["avatarCropped"]);
            if (ModelState.IsValid)
            {
                mr.member.MemberType = "member";
                mr.contact.Subscribed = "";
                mo.AddMemeber(mr.member);
                int a = int.Parse(mo.getMemberID()) - 1;
                if (mr.member.note != null && mr.member.note != "") {
                    mr.member.note = mr.member.note.Trim();
                }
                mr.contact.MemberID = int.Parse(a.ToString());
                co.AddContact(mr.contact);
                ViewBag.Message = " Successfully Add Member !!! ";
                ModelState.Clear();
            }
            ViewBag.ID = mo.getMemberID();
            return View();
        }
        [HttpGet]
        public JsonResult getMember() {
            
            DataTable dt = new DataTable();
            dt = mo.getMember();
            List<Member> data = new List<Member>();
            data = (from DataRow dr in dt.Rows
                    
                    select new Member()
                    {
                        Id = int.Parse(dr["Id"].ToString()),
                        FirstName = dr["FirstName"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        Gender = dr["Gender"].ToString(),
                        DOB = dr["DOB"].ToString(),
                        ImagePath = dr["ImgURL"].ToString()
                    }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult getMembershipWithMember() {
            DataTable dt = new DataTable();
            dt = mo.getMemberWithMembership();
            List<MemberDetails> md = new List<MemberDetails>();
            md = (from DataRow dr in dt.Rows
                  select new MemberDetails() {
                      Id = int.Parse(dr["Id"].ToString()),
                      FirstName = dr["FirstName"].ToString(),
                      LastName = dr["LastName"].ToString(),
                      Gender = dr["Gender"].ToString(),
                      DOB = dr["DOB"].ToString(),
                      ImagePath = dr["ImgURL"].ToString(),
                      MId = int.Parse(dr["MId"].ToString()),
                      Name = dr["Name"].ToString(),
                      Amount = decimal.Parse(dr["Amount"].ToString())
                  }
                ).ToList();
            return Json(md,JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult getMembershipWithMember(int? id) {
            List<MemberDetails> md = new List<MemberDetails>();
            md = mo.getMemberWithMembershipAll();
            var member1 = md.Find(x => x.Id.Equals(id));
            return Json(member1, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult getMember(int? id) {
            List<Member> mem = mo.getAllMembers();
            var member1 = mem.Find(x => x.Id.Equals(id));
            return Json(member1, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult getMembership(int? id) {
            ///   List<Member> mem = mo.getAllMembers();
            //   List<Membership> memshp = memOpt.getAllMembership();
            return View();
        }
        [AuthorizationPrivilegeFilter("Find Member", "View")]
        public ActionResult FindMember(int? id)
        {
            // Response.Write(" ID -: " + id);
            if (id != null)
            {
                Response.Write(" ID -: " + id);
            }
            else
            { 
            }
            List<Membership> st = memOpt.getAllMembership();
            model.memshp = st;
            return View(model);
        }
        string fullPath;
        string relativePath;
        private string uploadFile(HttpPostedFileBase file) {
            string trailingPath;
            if (file != null)
            {
                if (file.ContentType == "image/jpeg" || file.ContentType == "image/gif" || file.ContentType == "image/png")
                {
                    if (file.ContentLength < 1 * 1024 * 1024) 
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
                    else {
                        ModelState.AddModelError("member.ImagePath", "Please upload image less then 1 MB");
                        ViewBag.Message = "";
                    }
                }
                else {
                    ModelState.AddModelError("member.ImagePath", " Image formate not supportted ");
                    ViewBag.Message = "";
                }
            }
            else {
                relativePath = "/assets/images/users/deafult.png";
            }
            return relativePath;
        }
        public string SaveSnap(string base64) {

            string filename = "";
            string filename1 = "";
            if (base64 != "")
            {
                byte[] bytes = Convert.FromBase64String(base64.Split(',')[1]);
                filename = String.Format(@"{0}image-{1}.jpg", "~/assets/images/users/", DateTime.UtcNow.Ticks);
                filename1 = String.Format(@"{0}image-{1}.jpg", "/assets/images/users/", DateTime.UtcNow.Ticks);
                using (FileStream stream = new FileStream(Server.MapPath(filename), FileMode.Create))
                {
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Flush();
                }
            }
            else {
                filename1 = "/assets/images/users/deafult.png";
            }
           
            return filename1;
        }
        [AuthorizationPrivilegeFilter("Member", "Edit")]
        public ActionResult Edit(int? id) {
            if (Session["modules"] != null)
            {
                List<ModuleDetails> md = Session["modules"] as List<ModuleDetails>;
                ModuleDetails md1 = md.Find(x => x.Module.Equals("Member"));
                ViewBag.Edit = md1.Edit;
            }
            if (id == null)
            {
                ViewBag.ID = id;
                ViewBag.Alert = "none";
                ViewBag.Message = "";
                return View();
            }
            else
            {   
                dt = memOpt.getDTMembershipByID(id);
                List<gym_mgmt_01.Models.Membership> memlist = new List<gym_mgmt_01.Models.Membership>();
                memlist = ConvertDataTable<gym_mgmt_01.Models.Membership>(dt);
                ViewData["membership"] = memlist;
                Member mem = mo.getMember(id);
                Contact cn = co.GetContact(mem.Id);
                MemberRegistration m = new MemberRegistration();
                m.member = mem;
                ViewBag.ID = mem.Id;
                ViewBag.Message = "";
                m.contact = cn;
                return View(m);
            }
        }
        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List
                <T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizationPrivilegeFilter("Member", "Edit")]
        public ActionResult Edit(MemberRegistration mr) {

            var validImageTypes = new string[]
            {
                    "image/gif",
                    "image/jpeg",
                    "image/pjpeg",
                    "image/png"
            };
            if (mr.ImageFile == null || mr.ImageFile.ContentLength == 0)
            {
                //   ModelState.AddModelError("ImageUpload", "This field is required");
            }
            else if (!validImageTypes.Contains(mr.ImageFile.ContentType))
            {
                // ModelState.AddModelError("ImageUpload", "Please choose either a GIF, JPG or PNG image.");
            }
            mr.member.ImagePath = uploadFile(mr.ImageFile);
            if (ModelState.IsValid)
            {
                mr.member.MemberType = "member";
                mr.contact.Subscribed = "";
                mo.UpdateMember(mr.member);
                mr.contact.MemberID = mr.member.Id;
                co.UpdateContact(mr.contact);
                ViewBag.Message = "Successfully Update  Member !!!";
                ViewBag.ID = mo.getMemberID();
            }
            else {
                ViewBag.ID = mo.getMemberID();
                mr.member.ImagePath = "/assets/images/users/deafult.png";
            }
            return View(mr);
        }
        [HttpPost]
        public JsonResult IsAlreadyEmail(MemberRegistration mr , int? Id)
        {
            String mode = "";
            if (Id == null)
            {
                mode = "C";
            }
            else {
                mode = "E";
            }
            return Json(IsEmailAvailable(mr.contact.Email , mode));
        }
        public bool IsEmailAvailable(string email , string mode)
        {
            List<Contact> data = co.getAllContact();
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
        [HttpPost]
        public JsonResult IsAlreadyCell(MemberRegistration mr)
        {
            return Json(IsCellAvailable(mr.contact.Cell));
        }
        public bool IsCellAvailable(string cell)
        {    
            List<Contact> data = co.getAllContact();
            var gn = (from u in data
            where u.Cell.ToUpper() == cell.ToUpper()
            select new { cell }).FirstOrDefault();
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
        [HttpPost]
        public JsonResult updateMembership(int SubscriptionID, int MembershipID) {

            //Update the Membership Subscriptions.
            Subscriptions sub = new Subscriptions()
            {
                Id = SubscriptionID,
                MembershipID = MembershipID
            };
            bool result = so.UpdateSubscriptions(sub);
            if (result) {
                return Json(result);
            }
            return Json(result); 
        }
    }
}