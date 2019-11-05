using System;
using System.Collections.Generic;
using System.Linq;
using gym_mgmt_01.BAL.Master;
using gym_mgmt_01.Models;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data;

namespace gym_mgmt_01.Controllers
{
   
    public class CategoryController : Controller
    {
        ProductOperation po = new ProductOperation();
        dynamic model = new System.Dynamic.ExpandoObject();
        // GET: Category
        public ActionResult Index()
        {
            List<ProductType> productTypes = po.getAllProductType();
            model.prodTypeList = productTypes;
            model.ProductType = new ProductType();
            return View(model);
        }
        [HttpPost]
        public ActionResult SaveProductType(FormCollection fc)
        {
            // ProductType pt = new ProductType();
            // pt.TypeName = fc["typename"].ToString();
            // pt.TaxRateName = fc["taxrate"].ToString();
            // pt.SoldInClubs = fc["associatedclub"].ToString();
            po.AddProductType(fc["typename"].ToString(), fc["taxrate"].ToString(), fc["associatedclub"].ToString());
            ///  Response.Write("Hello  World");
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult EditProductType(FormCollection fc)
        {
            if (ModelState.IsValid)
            {
                po.UpdateProductType(int.Parse(fc["Id"].ToString()), fc["typename"].ToString(), fc["taxrate"].ToString(), fc["associatedclub"].ToString());
            }
            return RedirectToAction("Index");
        }
        public JsonResult ProductTypeEdit(int? id)
        {
            List<ProductType> productTypes = po.getAllProductType();
            var prod = productTypes.Find(x => x.Id.Equals(id));
            return Json(prod, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteProductType(int id)
        {
            try
            {
                bool result = po.DeleteProductType(id);
                if (result == true)
                {
                    ViewBag.Message = "Customer Deleted Successfully";
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