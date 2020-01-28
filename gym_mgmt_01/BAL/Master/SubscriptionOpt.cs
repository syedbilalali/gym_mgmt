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
                            MembershipName = dr["MembershipName"].ToString()
                        }).ToList();
            }
            return data;
        }
        public 
    }
}