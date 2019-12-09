using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rotativa.MVC;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using gym_mgmt_01.DAL;
using gym_mgmt_01.BAL.Master;
using gym_mgmt_01.Models;

namespace gym_mgmt_01.Controllers
{
    [Route("Invoice", Name = "invoice")]
    public class InvoiceController : Controller
    {
        // GET: Invoice

        SellsOrderItemsOpt soiOp = new SellsOrderItemsOpt();
        SellsOrderOpt soOp = new SellsOrderOpt();
        dynamic model = new System.Dynamic.ExpandoObject();
      //  private int invID = 0;
        public ActionResult Index()
        {
            // this.invID = getLastInvoiceID();
            int lastInvoiceID = getLastInvoiceID();
            ViewBag.Title = "Invoice ID : " +  lastInvoiceID;
            model.SellOrderItems = soiOp.getAlSellsOrderItemsByID(lastInvoiceID);
            model.SellOrder = soOp.getAlSellsOrderByID(lastInvoiceID);
            return View(model);
        }
        public ActionResult get_last_Invoice() {
            return new  ActionAsPdf("Index");
        }
        private int getLastInvoiceID() {

            //Get Last InvoiceID 
            int lastInvoiceID = soOp.getLastInvoiceIDINT();
            return lastInvoiceID;
        }
    }
}