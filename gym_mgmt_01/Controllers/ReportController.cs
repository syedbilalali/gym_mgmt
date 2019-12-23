﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gym_mgmt_01.Models;
using gym_mgmt_01.BAL.Master;
using System.Text;
using Rotativa.MVC;

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
        public ActionResult AllSubscriptions()
        {
            //Subscriptions Reports :
            List<SubscriptionReport> sbr = ro.getAllSubscriptionReport();
            model.subsReport = sbr;
            return View(model);

        }
        [HttpPost]
        public ActionResult AllSubscriptions(DateTime? fromdate, DateTime? todate)
        {
            List<SubscriptionReport> sbr = ro.getAllSubscriptionReport(fromdate, todate);
            model.subsReport = sbr;
            return View(model);
        }
        [HttpPost]
        public FileResult SubscriptionExport()
        {
            List<SubscriptionReport> subs = ro.getAllSubscriptionReport();
            List<object> sbr = (from sub in subs.ToList().Take(10)
                                select new[] { sub.Id.ToString(),
                                                            sub.MembershipName.ToString(),
                                                            sub.Amount.ToString(),
                                                            sub.ExpiryDate.ToString("dd-mm-yyyy"),
                                                            sub.Capacity.ToString(),
                                                            sub.MemberName.ToString()
                                }).ToList<object>();
            sbr.Insert(0, new string[6] { "Subscription ID", " Membership Name ", "Amount", " Expiry Date ", " Capacity ", " Member Name " });
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
            string current_date = DateTime.Now.ToShortDateString();

            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "Subscriptions_" + current_date + ".csv");
        }
        [HttpPost]
        public ActionResult SubscriptionsPrint()
        {
            return new Rotativa.MVC.ActionAsPdf("AllSubscriptions")
            { FileName = "Subscriptions.pdf" };
        }
        public ActionResult AllPayments()
        {
            List<SellsOrder> so = ro.getAlSellsOrder();
            model.sellsReport = so;
            return View(model);
        }
        [HttpPost]
        public ActionResult AllPaymentPrint(string Invoice_number)
        {
            return new Rotativa.MVC.ActionAsPdf("AllPayments", new { Invoice_number = Invoice_number })
            { FileName = "Payment.pdf" };
        }
        [HttpPost]
        public ActionResult PaymentsExport()
        {
            List<SellsOrder> so = ro.getAlSellsOrder();
            List<object> sor = (from sos in so.ToList()
                                select new[] { sos.Invoice_number.ToString(),
                                               sos.Member_Name.ToString(),
                                               sos.Subtotal.ToString(),
                                               sos.Sales_Tax.ToString(),
                                                            sos.Total_Amount.ToString(),
                                                             sos.Total_Pay.ToString(),
                                                             sos.Remain_price.ToString(),
                                                               sos.Paid_Status.ToString()
                                }).ToList<object>();
            sor.Insert(0, new string[8] { " Invoice No. ", " Member Name ", " Sub Total ", " Sales Tax ", "Total Amount ", " Total Pay ", " Remain Price ", " Paid Status " });
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < sor.Count; i++)
            {

                string[] customer = (string[])sor[i];
                for (int j = 0; j < customer.Length; j++)
                {
                    //Append data with separator.
                    sb.Append(customer[j] + ',');
                }
                //Append new line character.
                sb.Append("\r\n");

            }
            string current_date = DateTime.Now.ToShortDateString();


            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "PaymentsRpt_" + current_date + ".csv");
        }
        public ActionResult AllBills()
        {
            // All Invoice Report 
            List<SellsOrder> so = ro.getAlSellsOrder();
            model.sellsReport = so;
            return View(model);
        }
        [HttpPost]
        public ActionResult AllBills(DateTime? fromdate, DateTime? todate)
        {
            List<SellsOrder> so = ro.getAlSellsOrder(fromdate, todate);
            model.sellsReport = so;
            return View(model);
        }
        [HttpPost]
        public ActionResult AllBillsExport()
        {
            List<SellsOrder> sells = ro.getAlSellsOrder();
            List<object> so = (from sell in sells.ToList()
                               select new[] { sell.Invoice_number.ToString(),
                                                            sell.Member_Name.ToString(),
                                                            sell.Subtotal.ToString(),
                                                            sell.Sales_Tax.ToString(),
                                                            sell.Total_Amount.ToString(),
                                                            sell.Paid_Status.ToString(),
                                                            sell.Total_Pay.ToString(),
                                                            sell.Discount_Price.ToString(),
                                                            sell.Remain_price.ToString(),
                                                            sell.CreatedAt.ToString("dd-mm-yyyy")

                                }).ToList<object>();
            so.Insert(0, new string[10] { " Invoice No. ", "Member_Name", "Subtotal ", "Sales_Tax", " Total_Amount ", " Paid_Status ", " Total_Pay ", " Discount_Price", "Remain_price", "CreatedAt" });
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < so.Count; i++)
            {

                string[] customer = (string[])so[i];
                for (int j = 0; j < customer.Length; j++)
                {
                    //Append data with separator.
                    sb.Append(customer[j] + ',');
                }
                //Append new line character.
                sb.Append("\r\n");
            }
            string current_date = DateTime.Now.ToShortDateString();
            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "BillDated" + current_date + ".csv");
        }
        public ActionResult AllBillsPrint(string Invoice_number)
        {
            return new Rotativa.MVC.ActionAsPdf("AllBills", new { Invoice_number = Invoice_number })
            { FileName = "Bill.pdf" };
        }
        public ActionResult AllVisitor()
        {
            return View();
        }

    }
}