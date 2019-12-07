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

namespace gym_mgmt_01.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        // GET: Member
        MemberOperation mo = new MemberOperation();
        ContactOpration co = new ContactOpration();
        MembershipOpt memOpt = new MembershipOpt();
        DataTable dt = new DataTable();
        dynamic model = new System.Dynamic.ExpandoObject();
        //   EmergencyContactOpt eco = new EmergencyContactOpt();
        //  AddtionalDetailsOpt ado = new AddtionalDetailsOpt();
        //  PropectusOperation po = new PropectusOperation();
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                ViewBag.ID = mo.getMemberID();
                //   MemberID = int.Parse(mo.getMemberID());
                
                ViewBag.Alert = "none";
                return View();
            }
            else {

                    
                Member mem = mo.getMember(id);
                ViewBag.ID = mem.Id;
                model.data = mem;
                ViewBag.Alert = "none";
                return View(mem);
            }

        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection fc, HttpPostedFileBase ImageFile)  {
            if (ModelState.IsValid)
            {
                Member m1 = new Member();
                Contact con = new Contact();
                m1.FirstName = fc["FirstName"];
                m1.LastName = fc["LastName"];
                m1.DOB = fc["dob"];
                m1.Gender = fc["gender"];
                m1.note = fc["note"];
                m1.MemberType = fc["memberType"];
                string path = uploadFile(ImageFile);
                m1.ImagePath = path;
                con.MemberID = int.Parse(mo.getMemberID()); ;
                con.Cell = fc["Cell"];
                con.Email = fc["Email"];
                con.Home = fc["Home"];
                con.Work = fc["Work"];
                con.Address = fc["Address"];
                con.Suburb = fc["Suburb"];
                con.City = fc["City"];
                con.Zipcode = fc["Zipcode"];
                con.Subscribed = "";
                
                mo.AddMemeber(m1);
                co.AddContact(con);
                
                ViewBag.ID = mo.getMemberID();
                ViewBag.Alert = "block";
                ViewBag.Message = "Successfully add Member !!! ";
            }
            else {
                ViewBag.Message = "Something went wrong !!! ";
            }
            //return RedirectToAction ("Index");
            return View(fc);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(MemberRegistration mr) {
            if (ModelState.IsValid)
            {
                mr.member.ImagePath = mr.member.ImageUri; 
                mr.member.MemberType = "member";
                mr.contact.Subscribed = "";
                mo.AddMemeber(mr.member);
                co.AddContact(mr.contact);
                ViewBag.Message = "Successfully add Member !!! ";


            }
            return View("Index");
        }
        [HttpPost]
        public JsonResult putJSON(string searchValue) {

            string data = searchValue + " WORLD ";
            return Json(data, JsonRequestBehavior.AllowGet);
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
                        ImagePath = dr["ImgURL"].ToString()
                    }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult FindMember(int? id)
        {
            //    Response.Write(" ID -: " + id);
            if (id != null)
            {
                Response.Write(" ID -: " + id);
            }
            else
            {
                //   Response.Write(" ID No");
            }
            List<Membership> st = memOpt.getAllMembership();
            model.memshp = st;
            return View(model);
        }
        public string DataTableToJSONWithJavaScriptSerializer(DataTable table)
        {
            System.Web.Script.Serialization.JavaScriptSerializer jsSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in table.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }
            return jsSerializer.Serialize(parentRow);
        }
        public string DataTableToJSONWithStringBuilder(DataTable table)
        {
            var JSONString = new System.Text.StringBuilder();
            if (table.Rows.Count > 0)
            {
                JSONString.Append("[");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    JSONString.Append("{");
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        if (j < table.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\",");
                        }
                        else if (j == table.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\"");
                        }
                    }
                    if (i == table.Rows.Count - 1)
                    {
                        JSONString.Append("}");
                    }
                    else
                    {
                        JSONString.Append("},");
                    }
                }
                JSONString.Append("]");
            }
            return JSONString.ToString();
        }
        string fullPath;
        string relativePath;
        private string uploadFile(HttpPostedFileBase file) {
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
                }
                else {
                    Response.Write(" File Formate Not supported");
                }

            }
            else {
                relativePath = "/assets/images/users/user4.png";

            }
            return relativePath;
        }
        public ActionResult Edit(int? id) {
            if (id == null)
            {
                ViewBag.ID = mo.getMemberID();
                //   MemberID = int.Parse(mo.getMemberID());
                ViewBag.Alert = "none";
                return View();
            }
            else
            {
                dt = memOpt.getDTMembershipByID(id);
                List<gym_mgmt_01.Models.Membership> memlist = new List<gym_mgmt_01.Models.Membership>();
                memlist = ConvertDataTable<gym_mgmt_01.Models.Membership>(dt);
                ViewData["membership"] = memlist;
                Member mem = mo.getMember(id);
                Contact cn = co.GetContact(id);
              //  Contact con = 
                MemberRegistration m = new MemberRegistration();
              //  m.member.MemberType = "";
               // m.contact.Subscribed = "";
                 m.member = mem;
                 m.contact = cn;
               // mem.ImagePath = null;
             //   m.contact = con;
             ///   mo.UpdateMember(m.member);
              //  co.UpdateContact(m.contact);
                ViewBag.Message = "Update Member Data Here!!! ";
                
                //mem.ImagePath = mem.ImageUri;

                //ViewBag.ID = mem.Id;
                //model.data = mem;
                //ViewBag.Alert = "none";
                return View(m);
            }
        }
        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
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
        public ActionResult Edit(FormCollection fc , HttpPostedFileBase ImageFile) {
            if (ModelState.IsValid)
            {

                Member m1 = new Member();
                Contact con = new Contact();
                m1.FirstName = fc["FirstName"];
                m1.LastName = fc["LastName"];
                m1.DOB = fc["dob"];
                m1.Gender = fc["gender"];
                m1.note = fc["note"];
                m1.MemberType = fc["memberType"];
                string path = uploadFile(ImageFile);
                m1.ImagePath = path;
               // con.MemberID = int.Parse(mo.getMemberID()); ;
                con.Cell = fc["Cell"];
                con.Email = fc["Email"];
                con.Home = fc["Home"];
                con.Work = fc["Work"];
                con.Address = fc["Address"];
                con.Suburb = fc["Suburb"];
                con.City = fc["City"];
                con.Zipcode = fc["Zipcode"];
                con.Subscribed = "";
                mo.UpdateMember(m1);
                co.AddContact(con);
                ViewBag.ID = mo.getMemberID();
                ViewBag.Alert = "block";
                ViewBag.Message = "Successfully add Member !!! ";
            }
            //return RedirectToAction ("Index");
            return View();
        }
    }
}