using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gym_mgmt_01.Models;
using gym_mgmt_01.BAL.Master;
using System.Text;

namespace gym_mgmt_01.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        ReportOperation ro = new ReportOperation();
        dynamic model = new System.Dynamic.ExpandoObject();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AllSubscriptions() {

            //Subscriptions Reports :
            List<SubscriptionReport> sbr = ro.getAllSubscriptionReport();
            model.subsReport = sbr;
            return View(model);
        }
        [HttpPost]
        public ActionResult AllSubscriptions(DateTime? fromdate , DateTime? todate) {
            List<SubscriptionReport> sbr = ro.getAllSubscriptionReport(fromdate,todate);
            model.subsReport = sbr;
            return View(model);
        }
        [HttpPost]
        public FileResult SubscriptionExport() {
            List<SubscriptionReport> subs = ro.getAllSubscriptionReport();
            List<object> sbr = ( from sub in subs.ToList().Take(10)
                                 select new[] { sub.Id.ToString(),
                                                            sub.MembershipName.ToString(),
                                                            sub.Amount.ToString(),
                                                            sub.ExpiryDate.ToString("dd-mm-yyyy"),
                                                            sub.Capacity.ToString(),
                                                            sub.MemberName.ToString()
                                }).ToList<object>();
            sbr.Insert(0, new string[6] { "Subscription ID", " Membership Name ", "Amount", " Expiry Date " , " Capacity " , " Member Name " });
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < sbr.Count; i++)
            {   

                string[] customer = (string[])sbr[i];
                for (int j = 0; j < customer.Length; j++)
                {
                    //Append data with separator.
                    sb.Append(customer[j] + ',');
                }
                //Append new line character.
                sb.Append("\r\n");
            }
            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "Grid.csv");
        }
        public ActionResult AllPayments() {

            List<SellsOrder> so = ro.getAlSellsOrder();
            model.sellsReport = so;
            return View(model);
        }
        public ActionResult AllBills() {
            
            // All Invoice Report 
            List<SellsOrder> so = ro.getAlSellsOrder();
            model.sellsReport = so;
            return View(model);
        }
        [HttpPost]
        public ActionResult AllBills(DateTime? fromdate , DateTime? todate) {
            List<SellsOrder> so = ro.getAlSellsOrder(fromdate, todate);
            model.sellsReport = so;
            return View(model);
        }
        public ActionResult AllVisitor() {
            return View();
        }

    }
}