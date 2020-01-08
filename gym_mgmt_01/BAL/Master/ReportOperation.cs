using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using gym_mgmt_01.Models;
using gym_mgmt_01.DAL;
using System.Globalization;

namespace gym_mgmt_01.BAL.Master
{
    public class ReportOperation
    {
        DataAdapter da = new DataAdapter();
        public List<SubscriptionReport> getAllSubscriptionReport() {
            
            DataTable dt = new DataTable();
            List<SubscriptionReport> subs = new List<SubscriptionReport>();
            string command = "SELECT subs.Id , mem.Name , mem.Amount , mem.EndDate  , mem.Capacity , m.FirstName ";
            command += " FROM Subscriptions subs INNER JOIN dbo.Membership mem ON subs.MembershipID = mem.Id ";
            command += " INNER JOIN dbo.Member m ON subs.MemberID = m.Id ";
            dt = da.FetchAll(command);
            subs = (from DataRow dr in dt.Rows select new SubscriptionReport() {
                Id = int.Parse(dr["Id"].ToString()),
                MembershipName = dr["Name"].ToString(),
                Amount = decimal.Parse(dr["Amount"].ToString()),
                ExpiryDate = DateTime.Parse(dr["EndDate"].ToString()),
                Capacity =  dr["Capacity"].ToString(),
                MemberName = dr["FirstName"].ToString()
            }).ToList();
            return subs;
        }
        public List<SubscriptionReport> getAllSubscriptionReport(DateTime? fromdate , DateTime? todate)
        {

            DataTable dt = new DataTable();
            string fromdatest = String.Format("{0:yyyy-MM-dd}", fromdate) + " 00:00:00";
            string todatest = String.Format("{0:yyyy-MM-dd}", todate) + " 00:00:00";
            List<SubscriptionReport> subs = new List<SubscriptionReport>();
            string command = "SELECT subs.Id , mem.Name , mem.Amount , mem.EndDate  , mem.Capacity , m.FirstName ";
            command += " FROM Subscriptions subs INNER JOIN dbo.Membership mem ON subs.MembershipID = mem.Id ";
            command += " INNER JOIN dbo.Member m ON subs.MemberID = m.Id WHERE subs.CreatedAt BETWEEN '" +fromdatest+ "' AND '" +todatest+ "'";
            dt = da.FetchAll(command);
            subs = (from DataRow dr in dt.Rows
                    select new SubscriptionReport()
                    {
                        Id = int.Parse(dr["Id"].ToString()),
                        MembershipName = dr["Name"].ToString(),
                        Amount = decimal.Parse(dr["Amount"].ToString()),
                        ExpiryDate = DateTime.Parse(dr["EndDate"].ToString()),
                        Capacity = dr["Capacity"].ToString(),
                        MemberName = dr["FirstName"].ToString()
                    }).ToList();
            return subs;
        }
        public List<SellsOrder> getAlSellsOrder()
        {
            DataTable dt = new DataTable();
            string command = "SELECT * FROM dbo.SellsOrder";
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
        public List<SellsOrder> getAlSellsOrder(DateTime? fromdate, DateTime? todate)
        {
            DataTable dt = new DataTable();
            string fromdatest = String.Format("{0:yyyy-MM-dd}", fromdate) + " 00:00:00";
            string todatest = String.Format("{0:yyyy-MM-dd}", todate) + " 23:59:59"; 

            string command = "SELECT * FROM dbo.SellsOrder so WHERE so.CreatedAt BETWEEN '" + fromdatest + "' AND '" + todatest + "'";
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
    }
}