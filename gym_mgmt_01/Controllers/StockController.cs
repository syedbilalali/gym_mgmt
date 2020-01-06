using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gym_mgmt_01.BAL.Master;
using gym_mgmt_01.Models;
using System.Configuration;
using System.IO;
using System.Data;
using gym_mgmt_01.Helper_Code.Common;


namespace gym_mgmt_01.Controllers
{
    public class StockController : Controller
    {
        ProductOperation po = new ProductOperation();
        dynamic model = new System.Dynamic.ExpandoObject();
        // GET: Stock

        [AuthorizationPrivilegeFilter("Point of Sale", "View")]
        public ActionResult Index()
        {
            if (Session["modules"] != null)
            {
                List<ModuleDetails> md = Session["modules"] as List<ModuleDetails>;
                ModuleDetails md1 = md.Find(x => x.Module.Equals("Point of Sale"));
                ViewBag.Create = md1.Create;
                ViewBag.Edit = md1.Edit;
                ViewBag.Delete = md1.Delete;
            }
            List<Stocks> stocks = po.getAllStocks();
            List<Product> product = po.getAllProducts();
            model.products = product;
            model.stocks = stocks;  
            return View(model);
        }
        [HttpPost]
        [AuthorizationPrivilegeFilter("Point of Sale", "Create")]
        public ActionResult SaveStock(FormCollection fc)
        {
            if (ModelState.IsValid) {
                int productID = int.Parse(fc["productName"].ToString());
                int quantity = int.Parse(fc["quantity"].ToString());
                decimal get_price = decimal.Parse(fc["getprice"].ToString());
                decimal sell_price = decimal.Parse(fc["sellprice"].ToString());
                po.AddStocks(productID, get_price, sell_price, quantity, 0, quantity);
            }
            return RedirectToAction("Index");
        }
        [ChildActionOnly]
        public PartialViewResult updateStock() {

            List<Product> product = po.getAllProducts();
            model.products = product;
            return PartialView("_EditStock", model);
        }
        [AuthorizationPrivilegeFilter("Point of Sale", "Edit")]
        public ActionResult EditStock(Stocks fc)
        {
            if (ModelState.IsValid) {
                po.UpdateStocksIn(fc.Id, fc.get_price, fc.sell_price, fc.stockin, fc.current_stock);
                ModelState.Clear();
            }
            return RedirectToAction("Index");
        }
        [AuthorizationPrivilegeFilter("Point of Sale", "Delete")]
        public ActionResult DeleteStocks(int id)
        {
            try
            {
                bool result = po.DeleteStock(id);
                if (result == true)
                {
                    ViewBag.Message = "Stock Deleted Successfully";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.Message = "Unsucessfull";
                    ModelState.Clear();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                throw;
            }
        }
        [AuthorizationPrivilegeFilter("Point of Sale", "Edit")]
        public JsonResult StockEdit(int? id)
        {
            List<Stocks> stocks = po.getAllStocks();
            var prod = stocks.Find(x => x.Id.Equals(id));
            return Json(prod, JsonRequestBehavior.AllowGet);
        }
    }
}