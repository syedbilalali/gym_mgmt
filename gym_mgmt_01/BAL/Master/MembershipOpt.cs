using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gym_mgmt_01.DAL;
using System.Data.SqlClient;
using System.Data;
using gym_mgmt_01.Models;
namespace gym_mgmt_01.BAL.Master
{
    public class MembershipOpt
    {
        DataAdapter da = new DataAdapter();
        public MembershipOpt() { 
        }
        public bool AddMembership(Membership mem) {

            bool flag = false;
            string command = "physiofit_admin.spMembershipOpt";
            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@Action" , "INSERT");
            param[1] = new SqlParameter("@Name" , mem.Name);
            param[2] = new SqlParameter("@Description" , mem.Description);
            param[3] = new SqlParameter("@ValidDays" , mem.ValidDays );
            param[4] = new SqlParameter("@Amount" ,mem.Amount );
            param[5] = new SqlParameter("@StartDate" , mem.StartDate);
            param[6] = new SqlParameter("@EndDate" , mem.EndDate);
            param[7] = new SqlParameter("@PreEndDate" ,mem.PreEndDate );
            param[8] = new SqlParameter("@Capacity" ,mem.Capacity );
            flag = da.InsertSP(param, command);
            return flag;
        }
        public List<Membership> getAllMembership() {
            DataTable dt = new DataTable();
            string command = "SELECT * FROM physiofit_admin.Membership";
            List<Membership> mem = new List<Membership>();
            dt = da.FetchAll(command);
            if (dt.Rows.Count > 0) {
                mem = (from DataRow dr in dt.Rows
                       select new Membership()
                       {
                           Id = int.Parse(dr["Id"].ToString()),
                           Name = dr["Name"].ToString(),
                           Description = dr["Description"].ToString(),
                           ValidDays = int.Parse(dr["ValidDays"].ToString()),
                           Amount = decimal.Parse(dr["Amount"].ToString()),
                      //    StartDate = DateTime.Parse(dr["StartDate"].ToString()),
                           EndDate = DateTime.Parse(dr["EndDate"].ToString()),
                      //     PreEndDate = DateTime.Parse(dr["PreEndDate"].ToString()),
                           Capacity = int.Parse(dr["Capacity"].ToString()),
                       //    CreatedAt = DateTime.Parse(dr["CreatedAt"].ToString()),
                       //    UpdatedAt = DateTime.Parse(dr["UpdatedAt"].ToString())
                       }).ToList();
            }
            return mem;
        }
        public Membership getMembershipByID(int Id) {
            string command = "";
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            Membership data = new Membership();
            param[0] = new SqlParameter("@Id" , Id);
            dt  = da.FetchByParameter(param , command);
            if (dt.Rows.Count > 0)
            {
                data = new Membership()
                {
                    Id = int.Parse(dt.Rows[0]["Id"].ToString()),
                    Name = dt.Rows[0]["Name"].ToString(),
                    Description = dt.Rows[0]["Description"].ToString(),
                    ValidDays = int.Parse(dt.Rows[0]["ValidDays"].ToString()),
                    Amount = decimal.Parse(dt.Rows[0]["Amount"].ToString()),
                    StartDate = DateTime.Parse(dt.Rows[0]["StartDate"].ToString()),
                    EndDate = DateTime.Parse(dt.Rows[0]["EndDate"].ToString()),
                    PreEndDate = DateTime.Parse(dt.Rows[0]["PreEndDate"].ToString()),
                    Capacity = int.Parse(dt.Rows[0]["Capacity"].ToString()),
                    CreatedAt = DateTime.Parse(dt.Rows[0]["CreatedAt"].ToString()),
                    UpdatedAt = DateTime.Parse(dt.Rows[0]["UpdatedAt"].ToString())
                };
            }
            return data;
        } 
        public bool deleteMembership(int id) {
            string command = "physiofit_admin.spMembershipOpt";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Action" , "DELETE");
            param[1] = new SqlParameter("@Id" , id);
            return da.InsertSP(param , command);
        }
        public void UpdateMembership(Membership mem)
        {
            string command = "physiofit_admin.spMembershipOpt";
            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@Action", "UPDATE");
            param[1] = new SqlParameter("@Id", mem.Id);
            param[2] = new SqlParameter("@Name", mem.Name);
            param[3] = new SqlParameter("@Description", mem.Description);
            param[4] = new SqlParameter("@ValidDays", mem.ValidDays);
            param[5] = new SqlParameter("@Amount", mem.Amount);
            param[6] = new SqlParameter("@StartDate", mem.StartDate);
            param[7] = new SqlParameter("@EndDate", mem.EndDate);
            param[8] = new SqlParameter("@PreEndDate", mem.PreEndDate);
            param[9] = new SqlParameter("@Capacity", mem.Capacity);
            da.InsertSP(param, command);
        }
    }
}