using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using gym_mgmt_01.DAL;
using gym_mgmt_01.Models;

namespace gym_mgmt_01.BAL.Master
{
    public class MemberOperation
    {
        DataAdapter da = new DataAdapter();
        public MemberOperation() { 
        }
        public void AddMemeber(Member mb ) {
            //Insert Command 
            string command = "INSERT INTO physiofit_admin.Member(FirstName, LastName , DOB,Gender  , Note , MemberType, ImgURL) VALUES(@FirstName, @LastName ,@DOB,  @Gender ,@Note , @MemberType , @ImgURL)";
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@FirstName" , mb.FirstName);
            param[1] = new SqlParameter("@LastName" , mb.LastName);
            param[2] = new SqlParameter("@DOB", mb.DOB);
            param[3] = new SqlParameter("@Gender", mb.Gender);
            param[4] = new SqlParameter("@Note" , mb.note);
            param[5] = new SqlParameter("@MemberType", mb.MemberType);
            param[6] = new SqlParameter("@ImgURL" , mb.ImagePath);
            da.Insert(param , command);
        }
        public void UpdateMember(int id , Member mb) {
            string command = "";
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@FirstName", mb.FirstName);
            param[1] = new SqlParameter("@LastName", mb.LastName);
            param[2] = new SqlParameter("@Gender", mb.Gender);
            param[3] = new SqlParameter("@DOB", mb.DOB);
            param[4] = new SqlParameter("@Note", mb.note);
            param[5] = new SqlParameter("@ImgURL", mb.ImagePath);
            da.Insert(param, command);
        }
        public void DeleteMember(int id) {

            string command = "";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id",id);
            da.Insert(param , command);
        }
        public DataTable getMember() {
            DataTable dt = new DataTable();
            string command = "SELECT * FROM physiofit_admin.Member";
            return da.FetchAll(command);
        }
        public string getMemberID() {
            DataAdapter da = new DataAdapter();
            int lastID = da.getLastID("Id", " physiofit_admin.Member ");
            if (lastID != 0)
            {
                lastID++;
            }
            return lastID.ToString();
        }
    }
}