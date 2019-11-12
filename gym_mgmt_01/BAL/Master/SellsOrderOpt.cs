using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gym_mgmt_01.Models;
using gym_mgmt_01.DAL;
using System.Data;
using System.Data.SqlClient;

namespace gym_mgmt_01.BAL.Master
{
    public class SellsOrderOpt
    {
        DataAdapter da = new DataAdapter();
        DataTable dt = new DataTable();
        public SellsOrderOpt() {
        }
        public void addSellsOrder(SellsOrder so) {
            string command = "physiofit_admin.spInsertSellOrder";
            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@Invoice_number", so.Invoice_number);
            param[1] = new SqlParameter("@Member_name", so.Member_Name);
            param[2] = new SqlParameter("@Subtotal", so.Subtotal);
            param[3] = new SqlParameter("@Sales_Tax", so.Sales_Tax);
            param[4] = new SqlParameter("@Total_Amount", so.Total_Amount);
            param[5] = new SqlParameter("@Paid_Status", so.Paid_Status);
            param[6] = new SqlParameter("@Total_Pay", so.Total_Pay);
            param[7] = new SqlParameter("@Discount_price", so.Discount_Price);
            param[8] = new SqlParameter("@Remain_price", so.Remain_price);
            da.InsertSP(param, command);
        }
        public List<SellsOrder> getAlSellsOrder()
        {

            string command = "SELECT * FROM physiofit_admin.SellsOrder";
            List<SellsOrder> sellsOrder = new List<SellsOrder>();
            dt = da.FetchAll(command);
            if (dt.Rows.Count > 0)
            {
                sellsOrder = (from DataRow dr in dt.Rows
                                   select new SellsOrder()
                                   {
                                       Id = int.Parse(dr["Id"].ToString()),
                                       Invoice_number = dr["Invoice_number"].ToString(),
                                       Member_Name = dr["Member_name"].ToString(),
                                       Subtotal = decimal.Parse(dr["Subtotal"].ToString()),
                                       Sales_Tax = decimal.Parse(dr["Sales_Tax"].ToString()),
                                       Total_Amount = decimal.Parse(dr["Total_Amount"].ToString()),
                                       Paid_Status = dr["Paid_Status"].ToString(),
                                       Total_Pay = decimal.Parse(dr["Total_Pay"].ToString()),
                                       Discount_Price = decimal.Parse(dr["Discount_price"].ToString()),
                                       Remain_price = decimal.Parse(dr["Remain_price"].ToString()),
                                       CreatedAt = DateTime.Parse(dr["CreatedAt"].ToString())
                                   }).ToList();
            }
            return sellsOrder;
        }
        public string getLastInvoiceID()
        {   
            char pad = '0';
            char pad1 = '#';
            int a =  da.getLastID("Invoice_number", "dbo.SellsOrder");
            string b = a.ToString();
            string c =  b.PadLeft(4 , pad);
            return c.PadLeft(1, pad1);
        }
    }
}