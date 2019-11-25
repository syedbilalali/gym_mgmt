using System;
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
            string command = "dbo.spInsertProductType";
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
            string command = "dbo.spDeleteProducts";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id", Id);
            return da.InsertSP(param, command);
        }
        public List<ProductType> getAllProductType() {
            string command = "SELECT * FROM dbo.ProductType ";
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
        public List<Product> getAllProductByType(int id)
        {
            string command = "SELECT * FROM Products prod INNER JOIN Stocks stc ON prod.Id = stc.product_Id where Type_Id=" + id;
           // string command = "SELECT * FROM Products WHERE Type_Id=" + id;
            List<Product> product = new List<Product>();
            dt = da.FetchAll(command);
            if (dt.Rows.Count > 0)
            {
                product = (from DataRow dr in dt.Rows
                               select new Product()
                               {
                                   Id = int.Parse(dr["Id"].ToString()),
                                   Name = dr["Name"].ToString()
                               }).ToList();
            }
            return product;

        }
        //Products 
        public List<Product> getAllProducts()
        {
            string command = "SELECT * FROM dbo.Products";
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

            string command = "dbo.spInsertProducts";
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
            string command = "dbo.spUpdateProducts";
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@Id", Id);
            param[1] = new SqlParameter("@Name", Name);
            param[2] = new SqlParameter("@Type_Id", Type_Id);
            param[3]= new SqlParameter("@Supplier_Id", Supplier_Id);
            param[4] = new SqlParameter("@POS_Group_Id", POS_group_Id);
            param[5] = new SqlParameter("@Barcode", Barcode);
            param[6] = new SqlParameter("@Description", Description);
            param[7] = new SqlParameter("@ImageURL", ImageURL);
            da.InsertSP(param, command);
        }
        public bool DeleteProduct(int Id) {
            string command = "dbo.spDeleteProducts";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id", Id);
            return da.InsertSP(param, command);
        }
        //Stock
        public List<Stocks> getAllStocks()
        {
            string command = "SELECT st.* , prod.Name FROM Stocks st INNER JOIN Products prod ON st.product_Id = prod.Id;";
            List<Stocks> stocks = new List<Stocks>();
            dt = da.FetchAll(command);
            if (dt.Rows.Count > 0)
            {
                stocks = (from DataRow dr in dt.Rows
                          select new Stocks()
                          {
                              Id = int.Parse(dr["Id"].ToString()),
                              product_Id = int.Parse(dr["product_Id"].ToString()),
                              get_price = decimal.Parse(dr["get_price"].ToString()),
                              sell_price = decimal.Parse(dr["sell_price"].ToString()), 
                                   stockin = int.Parse(dr["stock_in"].ToString()),
                              stockout = int.Parse(dr["stock_out"].ToString()),
                              current_stock = int.Parse(dr["current_stock"].ToString()),
                              product_name = dr["Name"].ToString()

                          }).ToList();
            }
            return stocks;

        }
        public void AddStocks(int Product_Id ,decimal buyPrice , decimal sellPrice ,  int stock_in , int stock_out  , int current_stock) {

            string command = "dbo.spInsertStocks";
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@ProductID", Product_Id);
            param[1] = new SqlParameter("@get_price", buyPrice);
            param[2] = new SqlParameter("@sell_price", sellPrice);
            param[3] = new SqlParameter("@stock_in",  stock_in);
            param[4] = new SqlParameter("@stock_out", stock_out);
            param[5] = new SqlParameter("@current_stock", current_stock);
            da.InsertSP(param, command);
        }
        public void UpdateStocks(int stock_ID , int Product_Id, int stock_in, int stock_out, int current_stock, DateTime CreatedAt) {
            
            string command = "dbo.spUpdateStocks";
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@Id", stock_ID);
            param[1] = new SqlParameter("@ProductID", Product_Id);
            param[2] = new SqlParameter("@stock_in", stock_in);
            param[3] = new SqlParameter("@stock_out", stock_out);
            param[4] = new SqlParameter("@current_stock", current_stock);
            param[5] = new SqlParameter("@CreatedAt", CreatedAt);
            da.InsertSP(param, command);
        }
        public bool DeleteStock(int Id) {

            string command = "dbo.spDeleteStocks";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id", Id);
            return da.InsertSP(param, command);
        }
        public List<Item> getItems(int ItemID) {

            
            string command = "SELECT prod.Id as ProductID , st.Id as StockID , prod.Name , st.sell_price as SoldPrice , st.current_stock  as Stock   FROM Stocks st INNER JOIN Products prod ON st.product_Id = prod.Id where prod.Id=@Id";
            dt = new DataTable();
            List<Item> stocks = new List<Item>();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id", ItemID);
            dt = da.FetchByParameter(param , command);
            if (dt.Rows.Count > 0)
            {
                stocks = (from DataRow dr in dt.Rows
                          select new Item()
                          {
                            ItemID = int.Parse(dr["ProductID"].ToString()),
                            ItemName = dr["Name"].ToString(),
                            StockID = int.Parse(dr["StockID"].ToString()),
                            Qty = decimal.Parse(dr["Stock"].ToString()),
                            SellPrice = int.Parse(dr["SoldPrice"].ToString())
                          }).ToList();
            }
            return stocks;
        }
    }
}