﻿using System;
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
            string command = "dbo.spInsertClasses";
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
            string command = "dbo.spUpdateClasses";
            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@ClassName", class1.ClassName);
            param[1] = new SqlParameter("@From", class1.From);
            param[2] = new SqlParameter("@To", class1.To);
            param[3] = new SqlParameter("@Repeats", class1.Repeats);
            param[4] = new SqlParameter("@RepeatsEnd", class1.RepeatsEnd);
            param[5] = new SqlParameter("@Resource", class1.Resource);
            param[6] = new SqlParameter("@StaffID", class1.StaffID);
            param[7] = new SqlParameter("@Note", class1.Note);
            param[8] = new SqlParameter("@Id" , class1.Id);
            da.InsertSP(param, command);
        }
        public List<Classes> getAllClasses() {
            string command = "SELECT cls.*  , (st.FirstName +' '+ st.LastName) as Name  from dbo.Classes cls INNER JOIN Staff st ON  cls.StaffID = st.StaffID;";
            List<Classes> classes = new List<Classes>();
            dt = da.FetchAll(command);
            if (dt.Rows.Count > 0)
            {
                classes = (from DataRow dr in dt.Rows
                           select new Classes()
                           {
                               Id = int.Parse(dr["Id"].ToString()),
                               ClassName = dr["ClassName"].ToString(),
                               From = DateTime.Parse(dr["From"].ToString()),
                               FromStr = DateTime.Parse(dr["From"].ToString()).ToString("hh:mm:ss tt"),
                               To = DateTime.Parse(dr["To"].ToString()),
                               ToStr = DateTime.Parse(dr["To"].ToString()).ToString("hh:mm:ss tt"),
                               Repeats = dr["Repeats"].ToString(),
                               RepeatsEnd = DateTime.Parse(dr["RepeatsEnd"].ToString()),
                               Resource = dr["Resource"].ToString(),
                               StaffID = int.Parse(dr["StaffID"].ToString()),
                               StaffName = dr["Name"].ToString(),
                               Note = dr["Note"].ToString(),
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
        public bool deleteClassbyID(int id)
        {
            string command = "DELETE  FROM dbo.Classes WHERE Id=@Id";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id" , id);
            return da.Insert(param, command);
        }
        public void AddClassSubscriptions(ClassSubscriptions cs) {
            string command = "INSERT INTO dbo.ClassSubscriptions(ClassID , MemberID , CreatedAt) VALUES (@ClassID , @MemberID , CURRENT_TIMESTAMP)";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ClassID" ,cs.ClassID );
            param[1] = new SqlParameter("@MemberID" ,  cs.MemberID);
            da.Insert(param, command);
        }
        public void updateClassSubscription(int subscriptionID , int ClassID) {
            string command = "UPDATE dbo.ClassSubscriptions SET ClassID=@ClassID WHERE Id=@Id";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Id", subscriptionID);
            param[1] = new SqlParameter("@ClassID", ClassID);
            da.Insert(param, command);
        }
        public List<ClassSubscriptions> getAllClassSubs() {
            string command = "SELECT cs.Id ,cs.ClassID ,cs.MemberID , cls.ClassName , (mem.FirstName + ' ' + mem.LastName ) as MemberName , (st.FirstName + '' + st.LastName ) as TrainnerName , (cls.RepeatsEnd )as ExpirayDate , (cls.[From]) as FromTime,  (cls.[To]) as ToTime , cs.CreatedAt FROM ClassSubscriptions cs INNER JOIN Classes cls ON cs.ClassID = cls.Id INNER JOIN dbo.Member mem ON mem.Id = cs.MemberID  LEFT JOIN dbo.Staff st ON st.StaffID = cls.StaffID ";
            List<ClassSubscriptions> classes = new List<ClassSubscriptions>();
            dt = da.FetchAll(command);
            if (dt.Rows.Count > 0)
            {
                classes = (from DataRow dr in dt.Rows
                           select new ClassSubscriptions()
                           {
                               Id = int.Parse(dr["Id"].ToString()),
                               ClassID = int.Parse(dr["ClassID"].ToString()),
                               MemberID = int.Parse(dr["MemberID"].ToString()),
                               ClassName = dr["ClassName"].ToString(),
                               MemberName = dr["MemberName"].ToString(),
                               TrainnerName = dr["TrainnerName"].ToString(),
                               ExpirayDate = DateTime.Parse(dr["ExpirayDate"].ToString()),
                               FromTime = DateTime.Parse(dr["FromTime"].ToString()),
                               ToTime = DateTime.Parse(dr["ToTime"].ToString()),
                               CreatedAt = DateTime.Parse(dr["CreatedAt"].ToString())
                           }).ToList();
            }
            return classes;
        }
    }
}