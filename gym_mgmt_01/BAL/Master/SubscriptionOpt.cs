using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using gym_mgmt_01.DAL;
using gym_mgmt_01.Models;

namespace gym_mgmt_01.BAL.Master
{
    public class SubscriptionOpt
    {
        DataAdapter da = new DataAdapter();
        public void AddSubscriptions(Subscriptions so) {

            string command = "INSERT INTO dbo.Subscriptions(MembershipID, MemberID, Total_Amount,Paid_Amount,Due_Amount,Paid_Status,Status, CreatedAt)  VALUES (@MembershipID, @MemberID , @Total_Amount,@Paid_Amount,@Due_Amount,@Paid_Status,@Status,CURRENT_TIMESTAMP)";
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@MembershipID" , so.MembershipID);
            param[1] = new SqlParameter("@MemberID" ,so.MemberID);
            param[2] = new SqlParameter("@Total_Amount" ,so.Total_Amount);
            param[3] = new SqlParameter("@Paid_Amount" ,so.Paid_Amount);
            param[4] = new SqlParameter("@Due_Amount" ,so.Due_Amount);
            param[5] = new SqlParameter("@Paid_Status" ,so.Paid_Status);
            param[6] = new SqlParameter("@Status" ,so.Status);
            da.Insert(param, command);
        }
        public void AddSubscriptionsInvoice(SusbscriptionInvoice sbi) {

            string command = "INSERT INTO dbo.SubscriptionInvoice(SubscriptionID, Total_Amount,Paid_Amount, Due_Amount , Paid_Status , CreatedAt) VALUES(@SubscriptionID, @Total_Amount,@Paid_Amount, @Due_Amount , @Paid_Status ,CURRENT_TIMESTAMP)";
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@SubscriptionID",  sbi.SubscriptionID);
            param[1] = new SqlParameter("@Total_Amount", sbi.Total_Amount);
            param[2] = new SqlParameter("@Paid_Amount", sbi.Paid_Amount);
            param[3] = new SqlParameter("@Due_Amount", sbi.Due_Amount);
            param[4] = new SqlParameter("@Paid_Status",sbi.Paid_Status);
            da.Insert(param, command);
        }
        public int getLastSubscriptionID(int membershipID , int memberID) {

            DataTable dt = new DataTable();
            int lastID = 0;
            string command = "SELECT sub.Id from Subscriptions sub  WHERE sub.MemberID=@memberID  AND sub.MembershipID=@membershipID";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@memberID" , memberID);
            param[1] = new SqlParameter("@membershipID", membershipID);
            dt = da.FetchByParameter(param, command);
            if (dt.Rows.Count > 0) {
                lastID = int.Parse(dt.Rows[0]["Id"].ToString());
            }
            return lastID;
        }
        public bool updateSubscription(int susbcriptionID , decimal Paid_Amount , decimal Due_Amount ,string Paid_Status ) {
            
            string command = "UPDATE Subscriptions SET Paid_Amount=@Paid_Amount , Due_Amount=@Due_Amount  , Paid_Status=@Paid_Status WHERE Id=@Id";
            SqlParameter[] param = new SqlParameter[4];
            bool flag = false;
            param[0] = new SqlParameter("@Paid_Amount"  , Paid_Amount);
            param[1] = new SqlParameter("@Due_Amount", Due_Amount);
            param[2] = new SqlParameter("@Paid_Status", Paid_Status);
            param[3] = new SqlParameter("@Id"  , susbcriptionID);
            flag = da.Insert(param, command);
            return flag;
        }
        public List<SusbscriptionInvoice> GetSusbscriptionInvoices() {

            DataTable dt = new DataTable();
            List<SusbscriptionInvoice> data = new List<SusbscriptionInvoice>();
            string command = "SELECT * FROM SubscriptionInvoice";
            dt = da.FetchAll(command);
            if (dt.Rows.Count > 0)
            {
                data = (from DataRow dr in dt.Rows
                        select new SusbscriptionInvoice()
                        {
                            Id = int.Parse(dr["InvoiceID"].ToString()),
                            SubscriptionID = int.Parse(dr["SubscriptionID"].ToString()),
                            Total_Amount = decimal.Parse(dr["Total_Amount"].ToString()),
                            Paid_Amount = decimal.Parse(dr["Paid_Amount"].ToString()),
                            Due_Amount = decimal.Parse(dr["Due_Amount"].ToString()),
                            Paid_Status = dr["Paid_Status"].ToString(),
                            CreatedAt = DateTime.Parse(dr["CreatedAt"].ToString())
                        }).ToList();
            }
            return data;
        }
        public List<SusbscriptionInvoice> GetSusbscriptionInvoices(int subscriptionsID)
        {

            DataTable dt = new DataTable();
            List<SusbscriptionInvoice> data = new List<SusbscriptionInvoice>();
            string command = "SELECT * FROM SubscriptionInvoice WHERE SubscriptionID=@SubscriptionID";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@SubscriptionID", subscriptionsID);
            dt = da.FetchByParameter(param , command);
            if (dt.Rows.Count > 0)
            {
                data = (from DataRow dr in dt.Rows
                        select new SusbscriptionInvoice()
                        {
                            Id = int.Parse(dr["InvoiceID"].ToString()),
                            SubscriptionID = int.Parse(dr["SubscriptionID"].ToString()),
                            Total_Amount = decimal.Parse(dr["Total_Amount"].ToString()),
                            Paid_Amount = decimal.Parse(dr["Paid_Amount"].ToString()),
                            Due_Amount = decimal.Parse(dr["Due_Amount"].ToString()),
                            Paid_Status = dr["Paid_Status"].ToString(),
                            CreatedAt = DateTime.Parse(dr["CreatedAt"].ToString())
                        }).ToList();
            }
            return data;
        }
        public bool DeleteSubscriptionsInvoice(int Id)
        {
            string command = "DELETE FROM dbo.SubscriptionInvoice WHERE Id=@Id";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id", Id);
            return da.Insert(param, command);
        }
        public bool DeleteSubscriptions(int Id) {

            string command = "DELETE FROM dbo.Subscriptions WHERE Id=@Id";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id", Id);
            return da.Insert(param, command);
        }
        public bool UpdateSubscriptions(Subscriptions so) {
            
            string command = "UPDATE dbo.Subscriptions SET MembershipID=@MembershipID WHERE Id=@Id";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Id", so.Id);
            param[1] = new SqlParameter("@MembershipID", so.MembershipID);
            return  da.Insert(param, command);
        }
        public List<Subscriptions> getSubscriptionsByID(int? id) {

            List<Subscriptions> data = new List<Subscriptions>();
            string command = "dbo.spSubscriptions";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Action", "BY_ID");
            param[1] = new SqlParameter("@by_ID", id);
            DataTable dt = new DataTable();
            dt = da.FetchByParamSP(param, command);
            if (dt.Rows.Count > 0)
            {
                data = (from DataRow dr in dt.Rows
                        select new Subscriptions()
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            MemberID = int.Parse(dr["MemberID"].ToString()),
                            MembershipID = int.Parse(dr["MembershipID"].ToString()),
                            MemberName = dr["MemberName"].ToString(),
                            Ammount = decimal.Parse(dr["Ammount"].ToString()),
                            ExpirayDate = DateTime.Parse(dr["ExpirayDate"].ToString()),
                            Paid_Amount = decimal.Parse(dr["Paid_Amount"].ToString()),
                            Paid_Status = dr["Paid_Status"].ToString(),
                            Due_Amount = decimal.Parse(dr["Due_Amount"].ToString()),
                            MembershipName = dr["MembershipName"].ToString()
                        }).ToList();
            }
            return data;
        }
        public Subscriptions getSubscription(int? id) {
            try {
               
                Subscriptions sbs = new Subscriptions();
                sbs = this.getAllSubscriptions().First(i => i.Id == id);
                return sbs;

            } catch (Exception e) {
                return null;
            }
        }
        public List<Subscriptions> getAllSubscriptions()
        {
            List<Subscriptions> data = new List<Subscriptions>();
            string command = "dbo.spSubscriptions";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Action", "ALL_DATA");
            DataTable dt = new DataTable();
            dt = da.FetchByParamSP(param, command);
            if (dt.Rows.Count > 0)
            {
                data = (from DataRow dr in dt.Rows
                        select new Subscriptions()
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            MemberID = int.Parse(dr["MemberID"].ToString()),
                            MembershipID = int.Parse(dr["MembershipID"].ToString()),
                            MemberName = dr["MemberName"].ToString(),
                            Ammount = decimal.Parse(dr["Ammount"].ToString()),
                            ExpirayDate = DateTime.Parse(dr["ExpirayDate"].ToString()),
                            Paid_Amount = decimal.Parse(dr["Paid_Amount"].ToString()),
                            Paid_Status = dr["Paid_Status"].ToString(),
                            MembershipName = dr["MembershipName"].ToString(),
                            Due_Amount = decimal.Parse(dr["Due_Amount"].ToString())
                        }).ToList();
            }
            return data;
        }
        public Subscriptions getSubscriptionByMemberID(int? id)
        {
            try
            {

                Subscriptions sbs = new Subscriptions();
                sbs = this.getAllSubscriptions().First(i => i.MemberID == id);
                return sbs;
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}