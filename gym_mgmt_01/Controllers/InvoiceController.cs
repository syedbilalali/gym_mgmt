using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rotativa.MVC;
using System.Web.Mvc;

namespace gym_mgmt_01.Controllers
{
    [Route("Invoice", Name = "invoice")]
    public class InvoiceController : Controller
    {
        // GET: Invoice
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult get_last_Invoice() {
            return new  ActionAsPdf("Index");
        }
    }
}