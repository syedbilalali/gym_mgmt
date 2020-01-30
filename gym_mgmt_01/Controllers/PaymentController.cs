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
                List<SusbscriptionInvoice> sbInv = subs.GetSusbscriptionInvoices(data.Id);
                model.subs = data;
                model.sbIn = sbInv;
                ViewBag.ID = id;
            }
            return View(model);
        }
        public ActionResult addSubscription(SusbscriptionInvoice subInv) {

            //Add Susbcription Invocie.
            //Update Susbcription 
            if (ModelState.IsValid) {

                decimal Last_Paid_Amount = subInv.Total_Amount - subInv.LeftSubscriptionCost;
                decimal Paid_Amount = subInv.Paid_Amount + Last_Paid_Amount;
                decimal Due_Amount = subInv.Due_Amount;
                subs.updateSubscription(subInv.SubscriptionID, Paid_Amount, Due_Amount, subInv.Paid_Status);
                subs.AddSubscriptionsInvoice(subInv);
            }
           
         
            return RedirectToAction("Subscriptions", "Membership");
        }
    }
}