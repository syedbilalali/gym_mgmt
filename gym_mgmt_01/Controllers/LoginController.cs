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
        bool isValid;
        bool isValid1;
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
                isValid = ml.Login(Email , Password);
                isValid1 = so.Login(Email, Password);

                if (!isValid && isValid1) {

                    FormsAuthentication.SetAuthCookie(Email, false);
                    Session["user"] = "Staff";
                    Session["Email"] = Email;
                    Session["Password"] = Password;
                    return RedirectToAction("Index", "Home");
                }
                if (isValid)
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
            return RedirectToAction("Login");
        }
    }
}