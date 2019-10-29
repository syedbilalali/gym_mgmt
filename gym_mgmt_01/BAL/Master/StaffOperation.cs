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

            string command = "INSERT INTO Staff(StaffID,FirstName,LastName,Gender,Email,Password,Designation,ImgURL) VALUES(@StaffID,@FirstName,@LastName,@Gender,@Email,@Password, @Designation,@ImgURL)";
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@StaffID", pro.StaffID);
            param[1] = new SqlParameter("@FirstName", pro.FirstName);
            param[2] = new SqlParameter("@LastName", pro.LastName);
            param[3] = new SqlParameter("@Gender", pro.Gender);
            param[4] = new SqlParameter("@Email", pro.Email);
            param[5] = new SqlParameter("@Password", pro.Password);
            param[6] = new SqlParameter("@Designation", pro.Designation);
            param[7] = new SqlParameter("@ImgURL", pro.ImgURL);
            da.Insert(param, command);
        
        }
        public DataTable geAllStaff() {
            string command = "SELECT * FROM Staff";
            return da.FetchAll(command);
        }
    }
   
}