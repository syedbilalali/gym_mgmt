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
            List<ProductType> catType = po.getAllProductType();
            model.catType = catType;
            return View(model);
        }
        public ActionResult ProductType() {

            List<ProductType>  productTypes =  po.getAllProductType();
            model.prodTypeList = productTypes;
            model.ProductType = new ProductType();
            return View(model);
        }
        public ActionResult SalesLedger() {
            return View();
        }
        public ActionResult Create(ProductType prod)
        {

            return View();
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
            return RedirectToAction("ProductType");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveProduct(FormCollection fc , HttpPostedFileBase prodImage) {
            if (ModelState.IsValid) {

                string imagePath = uploadFile(prodImage);
                po.AddProduct(fc["productname"].ToString(), int.Parse(fc["productType"].ToString()), int.Parse(fc["supplier"].ToString()), int.Parse(fc["posGroup"].ToString()), fc["barcode"].ToString(), fc["description"].ToString(), imagePath);
            }
            return RedirectToAction("Products");
        }
        [HttpPost]
        public ActionResult EditProductType(FormCollection fc)
        {
            if (ModelState.IsValid) {
                po.UpdateProductType(int.Parse(fc["Id"].ToString()), fc["typename"].ToString(), fc["taxrate"].ToString(), fc["associatedclub"].ToString());
            }
            return RedirectToAction("Products");
        }
        [HttpPost]
        public ActionResult EditProduct(FormCollection fc , HttpPostedFileBase fileBase)
        {
            if (ModelState.IsValid) {
                string imagePath = uploadFile(fileBase);
            //    string ID = fc["id"].ToString();
            //     int Id = int.Parse(fc["id"].ToString());
            //    string productName = fc["productname"].ToString();
             //   int productTYpe = int.Parse(fc["productType"].ToString());
             //   int supplier = int.Parse(fc["supplier"].ToString());
               // int posGroup = int.Parse(fc["posGroup"].ToString());
              //  string barcode = fc["barcode"].ToString();
             //   string description = fc["description"].ToString();
                po.UpdateProduct(int.Parse(fc["id"].ToString()), fc["productname"].ToString(), int.Parse(fc["productType"].ToString()), int.Parse(fc["supplier"].ToString()), int.Parse(fc["posGroup"].ToString()), fc["barcode"].ToString(), fc["description"].ToString(), imagePath);
            }
            return RedirectToAction("Products");
        }
        public JsonResult ProductTypeEdit(int? id)
        {
            List<ProductType> productTypes = po.getAllProductType();
            var prod = productTypes.Find(x => x.Id.Equals(id));
            return Json(prod, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ProductEdit(int? id)
        {
            List<Product> productTypes = po.getAllProducts();
            var prod = productTypes.Find(x => x.Id.Equals(id));
            return Json(prod, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Products() {

            List<Product> product = po.getAllProducts();
            List<ProductType> productType = po.getAllProductType();
            model.product = product;
            model.productType = productType;
            return View(model);
        }
        string fullPath;
        string relativePath;
        private string uploadFile(HttpPostedFileBase file)
        {
            string trailingPath;
            if (file != null)
            {
                if (file.ContentType == "image/jpeg")
                {
                    if (file.ContentLength < 102400)
                    {

                        string FileName = Path.GetFileNameWithoutExtension(file.FileName);

                        //To Get File Extension  
                        string FileExtension = Path.GetExtension(file.FileName);

                        //Add Current Date To Attached File Name  
                        FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;

                        //Get Upload path from Web.Config file AppSettings.  
                        string UploadPath = ConfigurationManager.AppSettings["UserImagePath"].ToString();

                        //Its Create complete path to store in server.  
                        //  string ImagePath = UploadPath + FileName;
                        trailingPath = Path.GetFileName(file.FileName);
                        fullPath = Path.Combine(Server.MapPath("~/assets/images/products/"), trailingPath);
                        relativePath = "/assets/images/products/" + trailingPath;
                        //To copy and save file into server.  
                        file.SaveAs(fullPath);
                    }
                    else {
                        relativePath = "/assets/images/products/prod_default.png";
                    }
                }
                else {
                    relativePath = "/assets/images/products/prod_default.png";
                }

            }
            else
            {
                relativePath = "/assets/images/products/prod_default.png";

            }
            return relativePath;
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

                return RedirectToAction("ProductType");
            }
            catch
            {
                throw;
            }
        }
        public ActionResult DeleteProducts(int id)
        {
            try
            {
                bool result = po.DeleteProducts(id);
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

                return RedirectToAction("Products");
            }
            catch
            {
                throw;
            }
        }
        public ActionResult Stock() {

            List<Stocks> stocks = po.getAllStocks();
            List<Product> product = po.getAllProducts();
            model.stocks = stocks;
            model.products = product;
            return View(model);
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
        public ActionResult SaveStock(FormCollection fc) {
    
            int productID = int.Parse(fc["productName"].ToString());
            int quantity = int.Parse(fc["quantity"].ToString());
            Response.Write("Hello World ");
            po.AddStocks(productID, quantity, 0, quantity);
            return RedirectToAction("Stock");
        }
        [HttpPost]
        public ActionResult EditStock()
        {
            return RedirectToAction("Stock");
        }
    }

}