using System;
using System.Collections.Generic;
using System.Linq;
using gym_mgmt_01.BAL.Master;
using gym_mgmt_01.Models;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data;
using gym_mgmt_01.Helper_Code.Common;

namespace gym_mgmt_01.Controllers
{
   
    public class CategoryController : Controller
    {
        ProductOperation po = new ProductOperation();
        dynamic model = new System.Dynamic.ExpandoObject();
        // GET: Category

        [AuthorizationPrivilegeFilter("Point of Sale" , "View")]
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

            List<ProductType> productTypes = po.getAllProductType();
            model.prodTypeList = productTypes;
            model.ProductType = new ProductType();
            return View(model);
        }
        [HttpPost]
        public ActionResult SaveProductType(FormCollection fc)
        {
            po.AddProductType(fc["typename"].ToString(), fc["taxrate"].ToString(), fc["associatedclub"].ToString());
            return RedirectToAction("Index");
        }
        [HttpPost]
        [AuthorizationPrivilegeFilter("Point of Sale", "Edit")]
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
        [AuthorizationPrivilegeFilter("Point of Sale", "Delete")]
        public ActionResult DeleteProductType(int id)
        {
            try
            {
                bool result = po.DeleteProductType(id);
                if (result == true)
                {
                    ViewBag.Message = "Category Deleted Successfully";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.Message = " Something went wrong. ";
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