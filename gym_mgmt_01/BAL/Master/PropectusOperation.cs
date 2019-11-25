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
    public class PropectusOperation
    {
        DataAdapter da = new DataAdapter();
        public PropectusOperation() { 

        }
        public void AddProspectus(Prospectus pro) {

            string command = "INSERT INTO dbo.Prospectus(MemberID ,ContactMethod,FitnessGoal ,PreviousGym LeadStrength,Created) VALUES(@MemberID ,@ContactMethod,@FitnessGoal ,@PreviousGym @LeadStrength,@Created)";
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@MemberID", pro.MemberID);
            param[1] = new SqlParameter("@ContactMethod", pro.ContactMethod);
            param[2] = new SqlParameter("@FitnessGoal", pro.FitnessGoal);
            param[3] = new SqlParameter("@PreviousGym", pro.PreviousGym);
            param[4] = new SqlParameter("@LeadStrength",pro.LeadStrength);
            param[5] = new SqlParameter("@Created", pro.Created);
            da.Insert(param, command);
        }

    }
}