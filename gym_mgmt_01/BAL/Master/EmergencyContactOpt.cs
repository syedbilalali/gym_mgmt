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
    public class EmergencyContactOpt
    {
        DataAdapter da = new DataAdapter();
        public EmergencyContactOpt() { 
        }
        public void AddEmergencyContact(EmergencyContact ec) {
            
            string command = "INSERT INTO dbo.EmergencyContact(MemberID ,FirstName,LastName ,Relationship,Email  , Cell, Home ,Work, MedicalInfo , Age) VALUES(@MemberID ,@FirstName,@LastName ,@Relationship,@Email  , @Cell, @Home ,@Work, @MedicalInfo , @Age)";
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@MemberID", ec.MemberID);
            param[1] = new SqlParameter("@FirstName", ec.FirstName);
            param[2] = new SqlParameter("@LastName", ec.LastName);
            param[3] = new SqlParameter("@Relationship",ec.Relationship);
            param[4] = new SqlParameter("@Email", ec.Email);
            param[5] = new SqlParameter("@Cell",ec.Cell);
            param[6] = new SqlParameter("@Home", ec.Home);
            param[7] = new SqlParameter("@Work", ec.Work);
            param[8] = new SqlParameter("@MedicalInfo", ec.MedicalInfo);
            param[9] = new SqlParameter("@Age",ec.Age);
            da.Insert(param, command);
        }
    }
}