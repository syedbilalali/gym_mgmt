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
            model.prod = new List<Product>(); 
            return View(model);
        }
        public ActionResult SalesLedger() {
            return View();
        }
        public ActionResult FindSub(int id) {
            //  Response.Write(" Data : " + id);
            List<Product> prod = po.getAllProductByType(id);
            List<ProductType> cat = new List<ProductType>();
            model.catType = cat;
            model.prod = prod;
            return View("Index" , model);
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
            ViewBag.Data = "Data";
            return RedirectToAction("Index");
        }
    }

}