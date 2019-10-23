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
        MasterLogin ml = new MasterLogin();
        bool isValid;
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
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(Email, false);
                    Session["Email"] = Email;
                    Session["Password"] = Password;
                    return RedirectToAction("Index", "Home");
                }
                    
            }
            //Response.Write(" Valid " + isValid);
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