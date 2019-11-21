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

            string command = "INSERT INTO Subscriptions(MembershipID, MemberID , CreatedAt)  VALUES (@MembershipID, @MemberID , CURRENT_TIMESTAMP)";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@MembershipID" , so.MembershipID);
            param[1] = new SqlParameter("@MemberID" ,so.MemberID);
            da.Insert(param, command);
        }
        public bool DeleteSubscriptions(int Id) {

            string command = "DELETE FROM dbo.Subscriptions WHERE Id=@Id";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id", Id);
            return da.Insert(param, command);
        }
        public void UpdateSubscriptions(Subscriptions so) {
            string command = "UPDATE physiofit_admin.Subscriptions SET MembershipID=@MembershipID , MemberID=@MemberID WHERE Id=@Id";
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Id", so.Id);
            param[1] = new SqlParameter("@MembershipID", so.MembershipID);
            param[2] = new SqlParameter("@MemberID", so.MemberID);
            da.Insert(param, command);
        }
        public List<Subscriptions> getAllSubscriptions() {
            List<Subscriptions> data  = new List<Subscriptions>();
            string command = "physiofit_admin.spSubscriptions";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Action" , "ALL_DATA");
            DataTable dt = new DataTable();
            dt = da.FetchByParamSP(param, command);
            if (dt.Rows.Count > 0) {
                data = (from DataRow dr in dt.Rows select new Subscriptions() {
                    Id = int.Parse(dr["Id"].ToString()),
                    MemberName = dr["MembershipName"].ToString(),
                    Ammount = decimal.Parse(dr["Ammount"].ToString()),
                    ExpirayDate = DateTime.Parse(dr["ExpirayDate"].ToString()),
                    MembershipName = dr["MemberName"].ToString()
                }).ToList();
            }
            return data;
        }
        //public List<Subscriptions> getAllSubscriptions(DateTime from , DateTime to) {
            
        //}
    }
}