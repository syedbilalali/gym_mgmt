﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using gym_mgmt_01.DAL;
using gym_mgmt_01.Models;

namespace gym_mgmt_01.BAL.Master
{
    public class ProductOperation
    {
        DataAdapter da = new DataAdapter();
        DataTable dt = new DataTable();
        public ProductOperation() { 
        }
        public void AddProductType(string Name , string Tax_Rate_Name  , string SoldInCLub) {
            string command = "physiofit_admin.spInsertProductType";
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Name" , Name);
            param[1] = new SqlParameter("@Tax_Rate_Name" , Tax_Rate_Name);
            param[2] = new SqlParameter("@SoldClub" , SoldInCLub);
            da.InsertSP(param, command);
        }
        public void UpdateProductType(int Id , string Name, string Tax_Rate_Name, string SoldInCLub) {

            string command = "spUpdateProductType";
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@Id", Id);
            param[1] = new SqlParameter("@Name", Name);
            param[2] = new SqlParameter("@Tax_Rate_Name", Tax_Rate_Name);
            param[3] = new SqlParameter("@Sold_Club", SoldInCLub);
            da.InsertSP(param, command);
        }
        public bool DeleteProductType(int Id) {

            string command = "spDeleteProductType";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id", Id);
           return  da.InsertSP(param, command);
        }
        public bool DeleteProducts(int Id)
        {
            string command = "physiofit_admin.spDeleteProducts";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id", Id);
            return da.InsertSP(param, command);
        }
        public List<ProductType> getAllProductType() {
            string command = "SELECT * FROM physiofit_admin.ProductType ";
            List<ProductType> productType = new List<ProductType>();
            dt = da.FetchAll(command);
            if (dt.Rows.Count > 0)
            {
                productType = (from DataRow dr in dt.Rows
                             select new ProductType()
                             {
                                 Id = int.Parse(dr["Id"].ToString()),
                                 TypeName = dr["Name"].ToString(),
                                 TaxRateName = dr["Tax_Rate_Name"].ToString(),
                                 SoldInClubs = dr["Sold_Club"].ToString(),
                                 CreatedAt = DateTime.Parse(dr["CreatedAt"].ToString())
                             }).ToList();
            }
            return productType;

        }
        public List<Product> getAllProducts()
        {
            string command = "SELECT * FROM Products";
            List<Product> productType = new List<Product>();
            dt = da.FetchAll(command);
            if (dt.Rows.Count > 0)
            {
                productType = (from DataRow dr in dt.Rows
                               select new Product()
                               {
                                   Id = int.Parse(dr["Id"].ToString()),
                                   Name = dr["Name"].ToString(),
                                   Type_Id = int.Parse(dr["Type_Id"].ToString()),
                                   Barcode = dr["Barcode"].ToString(),
                                   Description = dr["Description"].ToString(),
                                   ImageURL = dr["ImageURL"].ToString(),
                                   CreatedAt = DateTime.Parse(dr["CreatedAt"].ToString())
                               }).ToList();
            }
            return productType;

        }
        public void AddProduct(string Name , int Type_Id ,int Supplier_Id , int POS_group_Id , string Barcode , string Description, string ImageURL ) {

            string command = "physiofit_admin.spInsertProducts";
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@Name", Name);
            param[1] = new SqlParameter("@Type_Id", Type_Id);
            param[2] = new SqlParameter("@Supplier_Id", Supplier_Id);
            param[3] = new SqlParameter("@POS_Group_Id", POS_group_Id);
            param[4] = new SqlParameter("@Barcode", Barcode);
            param[5] = new SqlParameter("@Description", Description);
            param[6] = new SqlParameter("@ImageURL", ImageURL);
            da.InsertSP(param, command);
        }
        public void UpdateProduct(int Id , string Name, int Type_Id, int Supplier_Id, int POS_group_Id, string Barcode, string Description, string ImageURL)
        {
            string command = "physiofit_admin.spUpdateProducts";
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@Id", Id);
            param[1] = new SqlParameter("@Name", Name);
            param[2] = new SqlParameter("@Type_Id", Type_Id);
            param[3]= new SqlParameter("@Supplier_Id", Supplier_Id);
            param[4] = new SqlParameter("@POS_Group_Id", POS_group_Id);
            param[6] = new SqlParameter("@Barcode", Barcode);
            param[7] = new SqlParameter("@Description", Description);
            param[8] = new SqlParameter("@ImageURL", ImageURL);
            da.InsertSP(param, command);
        }
        public bool DeleteProduct(int Id) {
            string command = "spDeleteProducts";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id", Id);
            return da.InsertSP(param, command);
        }
    }
}