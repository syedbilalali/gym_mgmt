using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using gym_mgmt_01.DAL;
using gym_mgmt_01.BAL.Master;

namespace gym_mgmt_01.Controllers
{   
    [Authorize]
    public class HomeController : Controller
    {
        DataAdapter da = new DataAdapter();
        MasterLogin ml = new MasterLogin();
        DataTable dt = new DataTable();
        [Authorize]
        public ActionResult Index()
        {
           // Response.Write("Email " + Session["Email"].ToString());
          //  Response.Write(" Password " + Session["Password"].ToString());
            dt = ml.getData(Session["Email"].ToString() , Session["Password"].ToString());
            if (dt.Rows.Count > 0 )
            {
                ViewBag.ImageURL = dt.Rows[0]["ImageURL"].ToString();
                ViewBag.FirstName = dt.Rows[0]["FirstName"].ToString();
                ViewBag.LastName = dt.Rows[0]["LastName"].ToString();
                Session["ImageURL"] = dt.Rows[0]["ImageURL"].ToString();
                Session["FirstName"] = dt.Rows[0]["FirstName"].ToString();
                Session["LastName"] = dt.Rows[0]["LastName"].ToString();

                //  Response.Write(" Image URL " + ViewBag.ImageURL);
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}