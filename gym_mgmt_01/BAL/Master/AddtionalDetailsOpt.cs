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
    public class AddtionalDetailsOpt
    {
        DataAdapter da = new DataAdapter();
        public AddtionalDetailsOpt() { }
        public void AddAddtionalDetails(AdditionalDetails ad) {

            string command = "INSERT INTO AdditionalDetails(MemberID ,Club , TrainerID, JoiningDate , SalesRepID , SourcePromotionID ,ReferredMemberBy , Occupation , Organisation, InvolvementType) VALUES(@MemberID ,@Club , @TrainerID, @JoiningDate , @SalesRepID , @SourcePromotionID ,@ReferredMemberBy , @Occupation , @Organisation, @InvolvementType)";
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@MemberID", ad.MemberID);
            param[1] = new SqlParameter("@Club", ad.Club);
            param[2] = new SqlParameter("@TrainerID",ad.TrainerID);
            param[3] = new SqlParameter("@JoiningDate", ad.JoiningDate);
            param[4] = new SqlParameter("@SalesRepID",ad.SalesRepID);
            param[5] = new SqlParameter("@SourcePromotionID", ad.SourcePromotionID);
            param[6] = new SqlParameter("@ReferredMemberBy", ad.ReferredMemberBy);
            param[7] = new SqlParameter("@Occupation", ad.Occupation);
            param[8] = new SqlParameter("@Organisation", ad.Organisation);
            param[9] = new SqlParameter("@InvolvementType",ad.InvolvementType);
            da.Insert(param, command);
        }
    }
}