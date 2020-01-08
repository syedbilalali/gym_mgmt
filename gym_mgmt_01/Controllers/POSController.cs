using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gym_mgmt_01.BAL.Master;
using gym_mgmt_01.Models;
using System.Web.Mvc;
using System.Configuration;
using System.IO;
using System.Data;
using Rotativa.MVC;
using gym_mgmt_01.Helper_Code.Common;

namespace gym_mgmt_01.Controllers
{
    public class POSController : Controller
    {
        // GET: POS
        ProductOperation po = new ProductOperation();
        SellsOrderItemsOpt soiAdd = new SellsOrderItemsOpt();
        SellsOrderOpt soAdd = new SellsOrderOpt();
        MemberOperation memOpt = new MemberOperation();
        dynamic model = new System.Dynamic.ExpandoObject();

        [AuthorizationPrivilegeFilter("Point of Sale", "View")]
        public ActionResult Index()
        {
            //ViewBag.Data = "Data";
            List<ProductType> catType = po.getAllProductType();
            model.catType = catType;
            model.prod = new List<Product>(); 
            return View(model);
        }
        public ActionResult FindSub(int id) {
            //  Response.Write(" Data : " + id);
            List<Product> prod = po.getAllProductByType(id);
            List<ProductType> cat = new List<ProductType>();
            model.catType = cat;
            model.prod = prod;
            return View("Index" , model);
        }
        [NonAction]
        public SelectList ToSelectList(DataTable table, string valueField, string textField)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(new SelectListItem()
                {
                    Text = row[textField].ToString(),
                    Value = row[valueField].ToString()
                });
            }

            return new SelectList(list, "Value", "Text");
        }

        [HttpPost]
        public ActionResult Calc() {
            return View("Index");
        }
        public ActionResult getData(int id)
        {   
            Response.Write("Data IS : " + id);
            ViewBag.Data = "Data";
            return RedirectToAction("Index");
        }

        public ActionResult SalesLedger()
        {
            return View();
        }
        [HttpGet]
        public JsonResult getCategory() {
            List<ProductType> catType = po.getAllProductType();
            return Json(catType, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult getProducts(int id) {
            List<Product> prod = po.getAllProductByType(id);
            return Json(prod, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult getStock() {
            List<Stocks> stock = po.getAllStocks();
            return Json(stock, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult getInvoiceID() {

            string last = soAdd.getLastInvoiceID();
            return Json(last , JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult getItemsList(int id) {
            List<Item> items = po.getItems(id);
            if (items.Count < 1) {
                return Json("No Stock Found !!! ", JsonRequestBehavior.AllowGet);
            }
            return Json(items, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult addSellsOrderItems(SellsOrderItems soi) {
           //Adding the SellsOrderItems
           soiAdd.addSellsOrderItems(soi);
           var response = " Sucessfully Save SellsOrderItems No : " + soi.Invoice_Id;
           return Json( response, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult addSellsOrder(SellsOrder so) {
            soAdd.addSellsOrder(so);
            var response = "Sucessfully Save SellsOrder No : " + so.Invoice_number;
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult getMembers(string name) {
          DataTable dt =   memOpt.getMember(name);
          List<Member> memList = new List<Member>();
          if (dt.Rows.Count > 0) {
                memList = (from DataRow dr in dt.Rows
                           select new Member()
                           {
                               Id = int.Parse(dr["Id"].ToString()),
                               FirstName = dr["FirstName"].ToString(),
                               LastName = dr["LastName"].ToString(),
                               DOB = dr["DOB"].ToString(),
                               ImagePath = dr["ImgURL"].ToString()
                           }).ToList();
            }
          return Json(memList, JsonRequestBehavior.AllowGet);
        }
        public ActionResult printInvoice() {
            var data = new ActionAsPdf("Index");
            return data;
        }
    }

}