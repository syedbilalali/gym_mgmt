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

namespace gym_mgmt_01.Controllers
{
    public class POSController : Controller
    {
        // GET: POS
        ProductOperation po = new ProductOperation();
        dynamic model = new System.Dynamic.ExpandoObject();
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
    }

}