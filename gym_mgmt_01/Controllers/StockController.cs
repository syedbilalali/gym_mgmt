using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gym_mgmt_01.BAL.Master;
using gym_mgmt_01.Models;
using System.Web.Mvc;
using System.Configuration;
using System.IO;
using System.Data;

namespace gym_mgmt_01.Controllers
{
    public class StockController : Controller
    {
        ProductOperation po = new ProductOperation();
        dynamic model = new System.Dynamic.ExpandoObject();
        // GET: Stock
        public ActionResult Index()
        {
            List<Stocks> stocks = po.getAllStocks();
            List<Product> product = po.getAllProducts();
            model.stocks = stocks;
            model.products = product;
            return View(model);
        }
        [HttpPost]
        public ActionResult SaveStock(FormCollection fc)
        {
            int productID = int.Parse(fc["productName"].ToString());
            int quantity = int.Parse(fc["quantity"].ToString());
            po.AddStocks(productID, quantity, 0, quantity);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult EditStock()
        {
            return RedirectToAction("Index");
        }
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
    }
}