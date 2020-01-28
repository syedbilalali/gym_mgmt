using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gym_mgmt_01.BAL.Master;
using gym_mgmt_01.Models;



namespace gym_mgmt_01.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        SubscriptionOpt subs = new SubscriptionOpt();
        dynamic model = new System.Dynamic.ExpandoObject();
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }
        public ActionResult GetPayment(int? id) {
            if (id != null) {
                Subscriptions data = subs.getSubscription(id);
                model.subs = data;
                ViewBag.ID = id;
            }
            return View(model);
        }
    }
}