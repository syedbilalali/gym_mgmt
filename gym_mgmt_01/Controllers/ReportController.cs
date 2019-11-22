using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gym_mgmt_01.Models;
using gym_mgmt_01.BAL.Master;

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