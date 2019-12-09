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
    public class RoleOperation
    {
        DataAdapter da = new DataAdapter();
        DataTable dt;
        public RoleOperation() { 
        }
        public void AddRoles(int GroupID , string RoleFor) {
            string command = "dbo.spInsertRoleGroup";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@GroupID", GroupID);
            param[1] = new SqlParameter("@RoleFor", RoleFor);
            da.InsertSP(param, command);
        }
        public void AddRoleGroup(RoleGroup rg) {
            string command = "dbo.spInsertRoleGroup";
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@GroupName" , rg.GroupName);
            param[1] = new SqlParameter("@Description" , rg.Description);
            param[2] = new SqlParameter("@Access" , rg.Access);
            da.InsertSP(param , command);
        }
        public List<RoleGroup> getAllRoleGroup() {
            string command = " SELECT * FROM dbo.RoleGroup";
            List<RoleGroup> roleGroup = new List<RoleGroup>();
            dt =  da.FetchAll(command);
            if (dt.Rows.Count > 0) {
                roleGroup = (from DataRow dr in dt.Rows
                             select new RoleGroup()
                             {
                                 Id = int.Parse(dr["Id"].ToString()),
                                 GroupName = dr["GroupName"].ToString(),
                                 Description = dr["Description"].ToString(),
                                 Access = dr["Access"].ToString(),
                                 CreatedAt = DateTime.Parse(dr["CreatedAt"].ToString())
                             }).ToList();
            }
            return roleGroup;
        }
        public void AddUserRoles(int RoleGroupID , int RoleID  , int UserID) {
            string command = "dbo.spInsertUserRoles";
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@RoleGroupID", RoleGroupID);
            param[1] = new SqlParameter("@RoleID", RoleID);
            param[2] = new SqlParameter("@UserID", UserID);
            da.InsertSP(param, command);
        }
        public List<Role> getAllRole()
        {
            string command = "SELECT * FROM dbo.Roles";
            List<Role> roleGroup = new List<Role>();
            dt = da.FetchAll(command);
            if (dt.Rows.Count > 0)
            {
                roleGroup = (from DataRow dr in dt.Rows
                             select new Role()
                             {
                                 Id = int.Parse(dr["Id"].ToString()),
                                 Roles = dr["Role"].ToString(),
                                 CreatedAt = DateTime.Parse(dr["CreatedAt"].ToString())
                             }).ToList();
            }
            return roleGroup;
        }
        public List<UserRoles> getAllUserRoles() {
            string command = " SELECT * FROM dbo.UserRoles";
            List<UserRoles> roleGroup = new List<UserRoles>();
            dt = da.FetchAll(command);
            if (dt.Rows.Count > 0)
            {
                roleGroup = (from DataRow dr in dt.Rows
                             select new UserRoles()
                             {
                                 Id = int.Parse(dr["Id"].ToString()),
                                 RoleGroupID = int.Parse(dr["RoleGroupID"].ToString()),
                                 RoleID = int.Parse(dr["RoleID"].ToString()),
                                 UserID = int.Parse(dr["UserID"].ToString()),
                                 CreatedAt = DateTime.Parse(dr["CreatedAt"].ToString())
                             }).ToList();
            }
            return roleGroup;
        }
        public bool DeleteRoles(int Id) {
            string command = "DELETE FROM RoleGroup WHERE id=@Id";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id", Id);
            return da.Insert(param , command);
        }
        public List<Role> getRoles() {
            string command = "SELECT * FROM dbo.RoleGroup WHERE Access='Staff'";
            List<Role> roleGroup = new List<Role>();
            dt = da.FetchAll(command);
            if (dt.Rows.Count > 0)
            {
                roleGroup = (from DataRow dr in dt.Rows
                             select new Role()
                             {
                                 Id = int.Parse(dr["Id"].ToString()),
                                 Roles = dr["GroupName"].ToString(),
                                 CreatedAt = DateTime.Parse(dr["CreatedAt"].ToString())
                             }).ToList();
            }
            return roleGroup;
        }
    }
}