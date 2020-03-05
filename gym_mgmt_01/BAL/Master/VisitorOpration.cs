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
    public class VisitorOpration
    {
        DataAdapter da = new DataAdapter();
        public VisitorOpration() { 
        }
        public void AddVisit(Visitor visit) {

            string command = "INSERT INTO dbo.Visitors(UserID , Username, UserType ,Date,Clock ,Status ,CreatedAt) VALUES(@UserID, @Username,  @UserType ,@Date,@Clock ,@Status ,CURRENT_TIMESTAMP)";
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@UserID", visit.UserID);
            param[1] = new SqlParameter("@Username", visit.VisitorName);
            param[2] = new SqlParameter("@UserType", visit.UserType);
            param[3] = new SqlParameter("@Date", visit.Date);
            param[4] = new SqlParameter("@Clock", visit.Clock);
            param[5] = new SqlParameter("@Status", visit.Status);           
            da.Insert(param, command);
        }
    }
}