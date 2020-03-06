using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using gym_mgmt_01.Models;
using gym_mgmt_01.DAL;

namespace gym_mgmt_01.BAL.Master
{
    public class DashboardOperation
    {
        DataAdapter da = new DataAdapter();
        public int GetAllMembers() {

            int count = 0;
            DataTable dt = new DataTable();
            string command = "SELECT COUNT(*) as All_Members FROM Member";
            dt = da.FetchAll(command);
            if (dt.Rows.Count > 0) {
                count = int.Parse(dt.Rows[0]["All_Members"].ToString());
            }
            return count;
        }
        public int GetAllMemberships() {
            int count = 0;
            DataTable dt = new DataTable();
            string command = "SELECT COUNT(*) as ALL_Membership FROM Membership";
            dt = da.FetchAll(command);
            if (dt.Rows.Count > 0)
            {
                count = int.Parse(dt.Rows[0]["ALL_Membership"].ToString());
            }
            return count;
        }
        public int GetAllSubscriptions() {

            int count = 0;
            DataTable dt = new DataTable();
            string command = "SELECT COUNT(*) as ALL_Subscriptions FROM Subscriptions;";
            dt = da.FetchAll(command);
            if (dt.Rows.Count > 0)
            {
                count = int.Parse(dt.Rows[0]["ALL_Subscriptions"].ToString());
            }
            return count;
        }
        public int GetAllInvoices() {

            int count = 0;
            DataTable dt = new DataTable();
            string command = "SELECT COUNT(*) as ALL_Invoices FROM SellsOrder;";
            dt = da.FetchAll(command);
            if (dt.Rows.Count > 0)
            {
                count = int.Parse(dt.Rows[0]["ALL_Invoices"].ToString());
            }
            return count;
        }
    }
}