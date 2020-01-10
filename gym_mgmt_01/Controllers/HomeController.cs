using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using gym_mgmt_01.DAL;
using gym_mgmt_01.BAL.Master;
using gym_mgmt_01.Models;
using Newtonsoft.Json;


namespace gym_mgmt_01.Controllers
{   
    [Authorize]
    public class HomeController : Controller
    {
        DataAdapter da = new DataAdapter();
        MasterLogin mo = new MasterLogin();
        MasterOperation ml = new MasterOperation();
        StaffOperation so = new StaffOperation();
        SalesTaxOperations taxOperations = new SalesTaxOperations();
        DataTable dt = new DataTable();
        dynamic model = new System.Dynamic.ExpandoObject();
        [Authorize]
        public ActionResult Index()
        {   
              
            if (Session["Email"] != null && Session["Password"] != null && Session["user"].ToString() == "Admin")
            {
                dt = ml.getData(Session["Email"].ToString(), Session["Password"].ToString());
                if (dt.Rows.Count > 0)
                {
                    ViewBag.ImageURL = dt.Rows[0]["ImageURL"].ToString();
                    ViewBag.FirstName = dt.Rows[0]["FirstName"].ToString();
                    ViewBag.LastName = dt.Rows[0]["LastName"].ToString();
                    Session["ImageURL"] = dt.Rows[0]["ImageURL"].ToString();
                    Session["FirstName"] = dt.Rows[0]["FirstName"].ToString();
                    Session["LastName"] = dt.Rows[0]["LastName"].ToString();
                }
            }
            else if (Session["Email"] != null && Session["Password"] != null && Session["user"].ToString() == "Staff") {
                dt = so.getStaff(Session["Email"].ToString(), Session["Password"].ToString());
                if (dt.Rows.Count > 0) {
                    ViewBag.ImageURL = dt.Rows[0]["ImgURL"].ToString();
                    ViewBag.FirstName = dt.Rows[0]["FirstName"].ToString();
                    ViewBag.LastName = dt.Rows[0]["LastName"].ToString();
                    Session["ImageURL"] = dt.Rows[0]["ImgURL"].ToString();
                    Session["FirstName"] = dt.Rows[0]["FirstName"].ToString();
                    Session["LastName"] = dt.Rows[0]["LastName"].ToString();
                    var json = dt.Rows[0]["permisions"].ToString();
                    List<ModuleDetails> md = JsonConvert.DeserializeObject<List<ModuleDetails>>(json);
                    Session["modules"] = md;
                    }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
        public ActionResult SalesTax() {
            return View();
        }
        [HttpPost]
        public ActionResult SalesTax(SalesTax sales)
        {

            if (ModelState.IsValid)
            {
                if (sales != null)
                {
                    taxOperations.AddSalesTax(sales);
                    ModelState.Clear();
                    ViewBag.Message = " Sales Tax Updated successfully !!! ";
                }
            }
            return View(sales);
        }
        public ActionResult FindSalesTax()
        {
            if (Session["modules"] != null)
            {
                List<ModuleDetails> md = Session["modules"] as List<ModuleDetails>;
                ModuleDetails md1 = md.Find(x => x.Module.Equals("SalesTax"));
                ViewBag.Module = md1.Module;
                ViewBag.Create = md1.Create;
                ViewBag.Edit = md1.Edit;
                ViewBag.Delete = md1.Delete;
            }

            List<SalesTax> data = new List<SalesTax>();

            var dt = taxOperations.getAllSalesTax();
            data = dt.ToList();
            model.salestax = data;
            return View(model);
        }
        public JsonResult SalesTaxEdit(int id)
        {

            List<SalesTax> taxes = taxOperations.getAllSalesTax();
            var st = taxes.Find(x => x.Id.Equals(id));
            return Json(st, JsonRequestBehavior.AllowGet);
        }
        //[HttpPost]
        public ActionResult EditSalesTax(SalesTax st)
        {

            if (ModelState.IsValid)
            {
                if (st != null)
                {
                    taxOperations.updateSalesTax(st);
                    ModelState.Clear();
                    ViewBag.Message = " Sales Tax Updated successfully !!! ";
                }

            }
            return RedirectToAction("FindSalesTax");
        }


        public ActionResult DeleteSalesTax(int id)
        {
            try
            {
                bool result = taxOperations.deleteSalesTaxById(id);
                if (result == true)
                {
                    ViewBag.Message = "Sales Tax Value Deleted Successfully";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.Message = " Sorry Something went Wrong !!! ";
                    ModelState.Clear();
                }
                return RedirectToAction("FindSalesTax");
            }
            catch
            {
                throw;
            }
        }
        public ActionResult Settings()
        {
            return View();
        }
        public ActionResult AdminAccess()
        {
            return View();
        }
        public ActionResult NoAccess()
        {
            return View();
        }
    }
}