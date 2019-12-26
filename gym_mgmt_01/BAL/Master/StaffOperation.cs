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
            string command = "INSERT INTO dbo.Staff(FirstName,LastName,Gender,Email,Password,Designation,ImgURL , permisions) VALUES(@FirstName,@LastName,@Gender,@Email,@Password, @Designation,@ImgURL , @permisions)";
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@FirstName", pro.FirstName);
            param[1] = new SqlParameter("@LastName", pro.LastName);
            param[2] = new SqlParameter("@Gender", pro.Gender);
            param[3] = new SqlParameter("@Email", pro.Email);
            param[4] = new SqlParameter("@Password", pro.Password);
            param[5] = new SqlParameter("@Designation", pro.Designation);
            param[6] = new SqlParameter("@ImgURL", pro.ImgURL);
            param[7] = new SqlParameter("@permisions", pro.permission);

            da.Insert(param, command);
        }
        public void updateStaff(Staff pro)
        {
            string command = "UPDATE Staff SET FirstName=@FirstName,LastName=@LastName,Gender=@Gender,Email=@Email,Password=@Password,Designation=@Designation,ImgURL=@ImgURL WHERE StaffID=@StaffID";
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@FirstName", pro.FirstName);
            param[1] = new SqlParameter("@LastName", pro.LastName);
            param[2] = new SqlParameter("@Gender", pro.Gender);
            param[3] = new SqlParameter("@Email", pro.Email);
            param[4] = new SqlParameter("@Password", pro.Password);
            param[5] = new SqlParameter("@Designation", pro.Designation);
            param[6] = new SqlParameter("@ImgURL", pro.ImgURL);
            param[7] = new SqlParameter("@StaffID" , pro.StaffID);
            da.Insert(param, command);
        }
        public DataTable geAllStaff() {
            string command = "SELECT * FROM dbo.Staff Order By StaffID DESC";
            return da.FetchAll(command);
        }
        public void updatePermission(String perm , String staffID ) {
            
            string command = "UPDATE dbo.Staff SET permisions=@perm WHERE StaffID=@StaffID";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@StaffID" , staffID);
            param[1] = new SqlParameter("@perm" , perm);
            da.Insert(param , command);
        }
        public DataTable getStaffByID(int id) {
            string command = "SELECT * FROM dbo.Staff WHERE StaffID=@StaffID";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@StaffID", id);
            return da.FetchByParameter(param, command);
        }
        public bool deleteStaffByID(int StaffID) {
            string command = "DELETE FROM dbo.Staff WHERE StaffID=@StaffID";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@StaffID",StaffID);
            return da.Insert(param, command);
        }
        public List<Staff> getAllStaff() {
            string command = "SELECT * FROM dbo.Staff";
            List<Staff> st = new List<Staff>();
            DataTable dt = new DataTable();
            dt = da.FetchAll(command);
            if (dt.Rows.Count > 0) {
                st = (from DataRow dr in dt.Rows select new Staff() {
                    StaffID = dr["StaffID"].ToString(),
                    FirstName = dr["FirstName"].ToString(),
                    LastName = dr["LastName"].ToString(),
                    Gender = dr["Gender"].ToString(),
                    Email = dr["Email"].ToString(),
                    Password = dr["Password"].ToString(),
                    Designation = dr["Designation"].ToString(),
                    ImgURL = dr["ImgURL"].ToString(),
                    permission = dr["permisions"].ToString(),
                }).ToList();
            }
            return st;
        }
    }
   
}