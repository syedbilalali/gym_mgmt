using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using gym_mgmt_01.Models;
using gym_mgmt_01.DAL;

namespace gym_mgmt_01.BAL.Master
{
    public class SellsOrderItemsOpt
    {
        DataAdapter da = new DataAdapter();
        DataTable dt;
        public SellsOrderItemsOpt() { 
        }
        public void addSellsOrderItems(SellsOrderItems soi)  {
            string command = "dbo.spInsertSellOrderItems";
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@Invoice_Id", soi.Invoice_Id);
            param[1] = new SqlParameter("@Invoice_number", soi.Invoice_number);
            param[2] = new SqlParameter("@product_id",  soi.product_Id);
            param[3] = new SqlParameter("@quantity", soi.quantity);
            param[4] = new SqlParameter("@unit_price", soi.unit_price);
            param[5] = new SqlParameter("@discount_price", soi.discount_price);
            param[6] = new SqlParameter("@total_ammount", soi.total_price);
            da.InsertSP(param, command);
        }
        public void updateSellsOrderItems(SellsOrderItems soi) {

            string command = "dbo.spInsertProductType";
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@Invoice_Id", soi.Invoice_Id);
            param[1] = new SqlParameter("@product_Id", soi.product_Id);
            param[2] = new SqlParameter("@quantity", soi.quantity);
            param[3] = new SqlParameter("@unit_price", soi.unit_price);
            param[4] = new SqlParameter("@discount_price", soi.discount_price);
            param[5] = new SqlParameter("@total_ammount", soi.total_price);
            param[6] = new SqlParameter("@CreatedAt", soi.CreatedAt);
            da.InsertSP(param, command);
        }
        public List<SellsOrderItems> getAlSellsOrderItems() {

            string command = "SELECT * FROM dbo.P";
            List<SellsOrderItems> sellsOrderItems = new List<SellsOrderItems>();
            dt = da.FetchAll(command);
            if (dt.Rows.Count > 0)
            {
                sellsOrderItems = (from DataRow dr in dt.Rows
                               select new SellsOrderItems()
                               {
                                   Id = int.Parse(dr["Id"].ToString()),
                                   Invoice_Id =  int.Parse(dr["invoice_Id"].ToString()),
                                   product_Id = int.Parse(dr["product_Id"].ToString()),
                                   quantity = decimal.Parse(dr["quantity"].ToString()),
                                   unit_price = decimal.Parse(dr["unit_price"].ToString()),
                                   discount_price = decimal.Parse(dr["discount_price"].ToString()),
                                   total_price = decimal.Parse(dr["total_amount"].ToString()),
                                   CreatedAt = DateTime.Parse(dr["CreatedAt"].ToString())
                               }).ToList();
            }
            return sellsOrderItems;
        }
        public List<SellsOrderItems> getAlSellsOrderItemsByID(int id)
        {
            string command = "SELECT soi.* , po.Name FROM dbo.SalesOrderItems soi LEFT JOIN Products po ON soi.product_Id = po.Id WHERE invoice_Id=@Id";
            List<SellsOrderItems> sellsOrderItems = new List<SellsOrderItems>();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id", id);
            dt = da.FetchByParameter(param , command);
            if (dt.Rows.Count > 0)
            {
                sellsOrderItems = (from DataRow dr in dt.Rows
                                   select new SellsOrderItems()
                                   {
                                       Invoice_Id = int.Parse(dr["invoice_Id"].ToString()),
                                       Invoice_number = dr["Invoice_number"].ToString(),
                                       product_Id = int.Parse(dr["product_Id"].ToString()),
                                       quantity = decimal.Parse(dr["quantity"].ToString()),
                                       unit_price = decimal.Parse(dr["unit_price"].ToString()),
                                       discount_price = decimal.Parse(dr["discount_price"].ToString()),
                                       total_price = decimal.Parse(dr["total_amount"].ToString()),
                                       CreatedAt = DateTime.Parse(dr["CreatedAt"].ToString()),
                                       ProductName = dr["Name"].ToString()
                                   }).ToList();
            }
            return sellsOrderItems;
        }
    }
}