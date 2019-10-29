using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using gym_mgmt_01.Models;
using gym_mgmt_01.DAL;

namespace gym_mgmt_01.BAL.Master
{
    public class MasterLogin
    {

        DataAdapter da = new DataAdapter();
        public void addMasterLogin(String FirstName, String LastName , String Email , String Gender, String Password , String ImgURL) {

            string command = "";
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@FirstName",FirstName);
            param[1] = new SqlParameter("@LastName",LastName);
            param[2] = new SqlParameter("@Email",Email);
            param[3] = new SqlParameter("@Gender",Gender);
            param[4] = new SqlParameter("@Password",Password);
            param[5] = new SqlParameter("@ImageURL" , ImgURL);
            da.Insert(param , command);
        }
        public bool Login(String Email , String Password) {

            DataTable dt;
            bool allow = false;
            string command = "SELECT * FROM Master_Login WHERE Email=@Email and Password=@Password";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Email" , Email);
            param[1] = new SqlParameter("@Password" , Password);
            dt = da.FetchByParameter(param,command);
            if (dt.Rows.Count > 0) {
                if (dt.Rows[0]["Email"].ToString().Contains(Email) && dt.Rows[0]["Password"].ToString().Contains(Password)) {
                    allow = true;
                }
            }
            return allow;

        }
        public DataTable getData(String Email , String Password) {
            string command  = "SELECT * FROM Master_Login WHERE Email=@Email and Password=@Password";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Email", Email);
            param[1] = new SqlParameter("@Password", Password);
            return  da.FetchByParameter(param, command);
        }
        public void chnagePassword(String Email , String OldPassword , String NewPassword) {
            string command = "";
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Email" , Email);
            param[1] = new SqlParameter("@Password" , OldPassword);
            param[2] = new SqlParameter("@NewPassword" , NewPassword);
            da.Insert(param , command);
        }

    }
}