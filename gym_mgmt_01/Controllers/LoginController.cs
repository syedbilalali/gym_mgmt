using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gym_mgmt_01.BAL.Master;
using System.Web.Security;

namespace gym_mgmt_01.Controllers
{
    public class LoginController : Controller
    {
        MasterOperation ml = new MasterOperation();
        StaffOperation so = new StaffOperation();
        bool isStaff , isAdmin;
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection fc) {

            if (ModelState.IsValid) {
                    
                string Email = fc["Email"].ToString();
                string Password = fc["Password"].ToString();
                isAdmin = ml.Login(Email , Password);
                isStaff = so.Login(Email, Password);

                if (!isAdmin && isStaff) {
                    FormsAuthentication.SetAuthCookie(Email, false);
                    Session["user"] = "Staff";
                    Session["Email"] = Email;
                    Session["Password"] = Password;
                    return RedirectToAction("Index", "Home");
                }
                if (isAdmin)
                {   
                    FormsAuthentication.SetAuthCookie(Email, false);
                    Session["user"] = "Admin";
                    Session["Email"] = Email;
                    Session["Password"] = Password;
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("LogError", " Authentication Failed !!! ");
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        public ActionResult NoAccess() {
            return View();
        }
        [AllowAnonymous]
        [Route("api/h")]
        public JsonResult H() {
     
            return Json("Hello World");
        }
    }
}