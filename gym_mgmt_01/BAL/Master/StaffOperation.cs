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
    
    public class StaffOperation
    {
        DataAdapter da = new DataAdapter();
        public void AddStaff(Staff pro)
        {

            string command = "INSERT INTO physiofit_admin.Staff(FirstName,LastName,Gender,Email,Password,Designation,ImgURL) VALUES(@FirstName,@LastName,@Gender,@Email,@Password, @Designation,@ImgURL)";
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@FirstName", pro.FirstName);
            param[1] = new SqlParameter("@LastName", pro.LastName);
            param[2] = new SqlParameter("@Gender", pro.Gender);
            param[3] = new SqlParameter("@Email", pro.Email);
            param[4] = new SqlParameter("@Password", pro.Password);
            param[5] = new SqlParameter("@Designation", pro.Designation);
            param[6] = new SqlParameter("@ImgURL", pro.ImgURL);
            da.Insert(param, command);
        }
        public DataTable geAllStaff() {
            string command = "SELECT * FROM physiofit_admin.Staff";
            return da.FetchAll(command);
        }
        public DataTable getStaffByID(int id) {
            string command = "SELECT * FROM physiofit_admin.Staff WHERE StaffID=@StaffID";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@StaffID", id);
            return da.FetchByParameter(param, command);
        }
        public bool deleteStaffByID(int StaffID) {
            string command = "DELETE FROM physiofit_admin.Staff WHERE StaffID=@StaffID";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@StaffID",StaffID);
            return da.Insert(param, command);
        }
    }
   
}