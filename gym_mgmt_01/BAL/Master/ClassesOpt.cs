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
    public class ClassesOpt
    {
        DataAdapter da = new DataAdapter();
        DataTable dt;
        public void AddClasses(Classes class1) {
            string command = "";
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@ClassName" , class1.ClassName);
            param[1] = new SqlParameter("@From" , class1.From);
            param[2] = new SqlParameter("@To" , class1.To);
            param[3] = new SqlParameter("@Repeats" , class1.Repeats);
            param[4] = new SqlParameter("@RepeatsEnd" ,class1.RepeatsEnd);
            param[5] = new SqlParameter("@Resource" , class1.Resource);
            param[6] = new SqlParameter("@StaffID" ,class1.StaffID);
            param[7] = new SqlParameter("@Note" , class1.Note);
            da.InsertSP(param, command);
        }
        public void UpdateClass(Classes class1) {
            
        }
        public List<Classes> getAllClasses() {
            string command = "";
            List<Classes> classes = new List<Classes>();
            dt = da.FetchAll(command);
            if (dt.Rows.Count > 0)
            {
                classes = (from DataRow dr in dt.Rows
                           select new Classes()
                           {
                               Id = int.Parse(dr["Id"].ToString()),
                               ClassName = dr["Name"].ToString(),
                               From = DateTime.Parse(dr["Tax_Rate_Name"].ToString()),
                               To = DateTime.Parse(dr["Sold_Club"].ToString()),
                               Repeats = dr[""].ToString(),
                               RepeatsEnd = DateTime.Parse(dr[""].ToString()),
                               Resource = dr[""].ToString(),
                               StaffID = int.Parse(dr[""].ToString()),
                               Note = dr[""].ToString(),
                               CreatedAt = DateTime.Parse(dr["CreatedAt"].ToString())
                           }).ToList();
            }
            return classes;
        }
        public Classes getClassesByID(int id) {
            DataTable dt;
            string command = "";
            Classes cld = new Classes();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id" , id);
            dt = da.FetchByParameter(param , command);
            if (dt.Rows.Count > 0) {
                cld = new Classes()
                {
                    Id = int.Parse(dt.Rows[0]["Id"].ToString()),
                    ClassName = dt.Rows[0]["ClassName"].ToString(),
                    From = DateTime.Parse(dt.Rows[0]["Tax_Rate_Name"].ToString()),
                    To = DateTime.Parse(dt.Rows[0]["Sold_Club"].ToString()),
                    Repeats = dt.Rows[0]["Repeats"].ToString(),
                    RepeatsEnd = DateTime.Parse(dt.Rows[0]["RepeatsEnd"].ToString()),
                    Resource = dt.Rows[0]["Resource"].ToString(),
                    StaffID = int.Parse(dt.Rows[0]["StaffID"].ToString()),
                    Note = dt.Rows[0]["Note"].ToString()
                };
            }
            return cld;
        }
    }
}