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


namespace gym_mgmt_01.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        ProductOperation po = new ProductOperation();
        dynamic model = new System.Dynamic.ExpandoObject();
        public ActionResult Index()
        {
            List<Product> product = po.getAllProducts();
            List<ProductType> productType = po.getAllProductType();
            model.product = product;
            model.productType = productType;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveProduct(FormCollection fc, HttpPostedFileBase prodImage)
        {
            if (ModelState.IsValid)
            {
                string imagePath = uploadFile(prodImage);
                po.AddProduct(fc["productname"].ToString(), int.Parse(fc["productType"].ToString()), int.Parse(fc["supplier"].ToString()), int.Parse(fc["posGroup"].ToString()), fc["barcode"].ToString(), fc["description"].ToString(), imagePath);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult EditProduct(FormCollection fc, HttpPostedFileBase prodImage)
        {
            if (ModelState.IsValid)
            {
                string imagePath = uploadFile(prodImage);
                po.UpdateProduct(int.Parse(fc["id"].ToString()), fc["productname"].ToString(), int.Parse(fc["productType"].ToString()), int.Parse(fc["supplier"].ToString()), int.Parse(fc["posGroup"].ToString()), fc["barcode"].ToString(), fc["description"].ToString(), imagePath);
            }
            return RedirectToAction("Index");
        }
        public JsonResult ProductEdit(int? id)
        {
            List<Product> productTypes = po.getAllProducts();
            var prod = productTypes.Find(x => x.Id.Equals(id));
            return Json(prod, JsonRequestBehavior.AllowGet);
        }
        string fullPath;
        string relativePath;
        private string uploadFile(HttpPostedFileBase file)
        {
            string trailingPath;
            if (file != null)
            {
                if (file.ContentType == "image/jpeg" || file.ContentType == "image/png" || file.ContentType == "image/jpg")
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
                    else
                    {
                        relativePath = "/assets/images/products/prod_default.png";
                    }
                }
                else
                {
                    relativePath = "/assets/images/products/prod_default.png";
                }

            }
            else
            {
                relativePath = "/assets/images/products/prod_default.png";

            }
            return relativePath;
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

                return RedirectToAction("Index");
            }
            catch
            {
                throw;
            }
        }
    }
}