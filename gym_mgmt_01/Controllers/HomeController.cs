using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using gym_mgmt_01.DAL;
using gym_mgmt_01.BAL.Master;
using gym_mgmt_01.Models;
using Newtonsoft.Json;


namespace gym_mgmt_01.Controllers
{   
    [Authorize]
    public class HomeController : Controller
    {
        DataAdapter da = new DataAdapter();
        MasterLogin mo = new MasterLogin();
        MasterOperation ml = new MasterOperation();
        StaffOperation so = new StaffOperation();
        DataTable dt = new DataTable();
        [Authorize]
        public ActionResult Index()
        {   
              
            if (Session["Email"] != null && Session["Password"] != null && Session["user"].ToString() == "Admin")
            {
                dt = ml.getData(Session["Email"].ToString(), Session["Password"].ToString());
                if (dt.Rows.Count > 0)
                {
                    ViewBag.ImageURL = dt.Rows[0]["ImageURL"].ToString();
                    ViewBag.FirstName = dt.Rows[0]["FirstName"].ToString();
                    ViewBag.LastName = dt.Rows[0]["LastName"].ToString();
                    Session["ImageURL"] = dt.Rows[0]["ImageURL"].ToString();
                    Session["FirstName"] = dt.Rows[0]["FirstName"].ToString();
                    Session["LastName"] = dt.Rows[0]["LastName"].ToString();
                }
            }
            else if (Session["Email"] != null && Session["Password"] != null && Session["user"].ToString() == "Staff") {
                dt = so.getStaff(Session["Email"].ToString(), Session["Password"].ToString());
                if (dt.Rows.Count > 0) {
                    ViewBag.ImageURL = dt.Rows[0]["ImgURL"].ToString();
                    ViewBag.FirstName = dt.Rows[0]["FirstName"].ToString();
                    ViewBag.LastName = dt.Rows[0]["LastName"].ToString();
                    Session["ImageURL"] = dt.Rows[0]["ImgURL"].ToString();
                    Session["FirstName"] = dt.Rows[0]["FirstName"].ToString();
                    Session["LastName"] = dt.Rows[0]["LastName"].ToString();
                    var json = dt.Rows[0]["permisions"].ToString();
                    List<ModuleDetails> md = JsonConvert.DeserializeObject<List<ModuleDetails>>(json);
                    Session["modules"] = md;
                    }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}