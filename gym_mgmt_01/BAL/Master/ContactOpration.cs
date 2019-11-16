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
    public class ContactOpration
    {
        DataAdapter da = new DataAdapter();
        public ContactOpration() { 
        }
        public void AddContact(Contact c)
        {
            //Insert Command 
            string command = "INSERT INTO physiofit_admin.Contact(MemberID , Email, Cell ,Home,Work  , Address, Suburb , City, ZipCode, Subscribed) VALUES(@MemberID , @Email, @Cell ,@Home,@Work  , @Address, @Suburb , @City, @ZipCode, @Subscribed)";
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@MemberID", c.MemberID);
            param[1] = new SqlParameter("@Email", c.Email);
            param[2] = new SqlParameter("@Cell", c.Cell);
            param[3] = new SqlParameter("@Home", c.Home);
            param[4] = new SqlParameter("@Work", c.Work);
            param[5] = new SqlParameter("@Address", c.Address);
            param[6] = new SqlParameter("@Suburb", c.Suburb);
            param[7] = new SqlParameter("@City", c.City);
            param[8] = new SqlParameter("@ZipCode", c.Zipcode);
            param[9] = new SqlParameter("@Subscribed", c.Subscribed);
            da.Insert(param, command);
        }
        public void UpdateContact(Contact c)
        {
            //Insert Command 
            string command = "UPDATE physiofit_admin.Contact  SET MemberID=@MemberID ,Email= @Email,Cell=@Cell ,Home=@Home,Work=@Work ,Address=@Address, Suburb=@Suburb , City=@City, ZipCode=@ZipCode, Subscribed=@Subscribed WHERE Id=@Id";
            SqlParameter[] param = new SqlParameter[11];
            param[0] = new SqlParameter("@MemberID", c.MemberID);
            param[1] = new SqlParameter("@Email", c.Email);
            param[2] = new SqlParameter("@Cell", c.Cell);
            param[3] = new SqlParameter("@Home", c.Home);
            param[4] = new SqlParameter("@Work", c.Work);
            param[5] = new SqlParameter("@Address", c.Address);
            param[6] = new SqlParameter("@Suburb", c.Suburb);
            param[7] = new SqlParameter("@City", c.City);
            param[8] = new SqlParameter("@ZipCode", c.Zipcode);
            param[9] = new SqlParameter("@Subscribed", c.Subscribed);
            param[10] = new SqlParameter("@Id" , c.Id);
            da.Insert(param, command);
        }
    }
}