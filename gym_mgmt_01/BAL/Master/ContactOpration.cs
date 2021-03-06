﻿using System;
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
            string command = "INSERT INTO dbo.Contact(MemberID , Email, Cell ,Home,Work  , Address, Suburb , City, ZipCode, Subscribed) VALUES(@MemberID , @Email, @Cell ,@Home,@Work  , @Address, @Suburb , @City, @ZipCode, @Subscribed)";
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@MemberID", c.MemberID);
            param[1] = new SqlParameter("@Email", (c.Email==null)?"": c.Email);
            param[2] = new SqlParameter("@Cell", (c.Cell==null)? "" : c.Cell);
            param[3] = new SqlParameter("@Home", (c.Home==null)? "" : c.Home);
            param[4] = new SqlParameter("@Work", (c.Work==null)? "" : c.Work);
            param[5] = new SqlParameter("@Address", (c.Address==null) ? "" : c.Address);
            param[6] = new SqlParameter("@Suburb", (c.Suburb==null) ? "" :c.Suburb);
            param[7] = new SqlParameter("@City", (c.City==null)? "" : c.City);
            param[8] = new SqlParameter("@ZipCode", (c.Zipcode==null)? "" : c.Zipcode);
            param[9] = new SqlParameter("@Subscribed", (c.Subscribed==null)? "" : c.Subscribed);
            da.Insert(param, command);
        }
        public void UpdateContact(Contact c)
        {
            //Insert Command 
            string command = "UPDATE dbo.Contact  SET MemberID=@MemberID ,Email= @Email,Cell=@Cell ,Home=@Home,Work=@Work ,Address=@Address, Suburb=@Suburb , City=@City, ZipCode=@ZipCode, Subscribed=@Subscribed WHERE MemberID=@MemberID";
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@MemberID", c.MemberID);
            param[1] = new SqlParameter("@Email", (c.Email == null) ? "" : c.Email);
            param[2] = new SqlParameter("@Cell", (c.Cell == null) ? "" : c.Cell);
            param[3] = new SqlParameter("@Home", (c.Home == null) ? "" : c.Home);
            param[4] = new SqlParameter("@Work", (c.Work == null) ? "" : c.Work);
            param[5] = new SqlParameter("@Address", (c.Address == null) ? "" : c.Address);
            param[6] = new SqlParameter("@Suburb", (c.Suburb == null) ? "" : c.Suburb);
            param[7] = new SqlParameter("@City", (c.City == null) ? "" : c.City);
            param[8] = new SqlParameter("@ZipCode", (c.Zipcode == null) ? "" : c.Zipcode);
            param[9] = new SqlParameter("@Subscribed", (c.Subscribed == null) ? "" : c.Subscribed);
          //  param[10] = new SqlParameter("@Id" , c.Id);
            da.Insert(param, command);
        }
        public List<Contact> getAllContact()
        {
            DataTable dt = new DataTable();
            string command = "SELECT * FROM dbo.Contact";
            dt = da.FetchAll(command);
            List<Contact> data = new List<Contact>();
            if (dt.Rows.Count > 0)
            {
                data = (from DataRow dr in dt.Rows
                        select new Contact()
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            MemberID = int.Parse(dr["MemberID"].ToString()),
                            Email = dr["Email"].ToString(),
                            Cell = dr["Cell"].ToString(),
                            Home = dr["Home"].ToString(),
                            Work = dr["Work"].ToString(),
                            City = dr["City"].ToString(),
                            Zipcode = dr["Zipcode"].ToString()
                        }).ToList();
            }
            return data;
        }
        public Contact GetContact(int? id)
        {

            DataTable dt = new DataTable();
            string command = "SELECT * FROM dbo.Contact WHERE dbo.Contact.MemberID=@Id";
            SqlParameter[] param = new SqlParameter[1];
            Contact con = new Contact();
            param[0] = new SqlParameter("@Id", id);
            dt = da.FetchByParameter(param, command);
            if (dt.Rows.Count > 0)
            {
                con = new Contact()
                {
                    Id = int.Parse(dt.Rows[0]["Id"].ToString()),
                    MemberID = int.Parse(dt.Rows[0]["MemberId"].ToString()),
                    Email = dt.Rows[0]["Email"].ToString(),
                    Cell = dt.Rows[0]["Cell"].ToString(),
                    Home = dt.Rows[0]["Home"].ToString(),
                    Work = dt.Rows[0]["Work"].ToString(),
                    Address = dt.Rows[0]["Address"].ToString(),
                    Suburb = dt.Rows[0]["Suburb"].ToString(),
                    City = dt.Rows[0]["City"].ToString(),
                    Zipcode = dt.Rows[0]["Zipcode"].ToString(),
                    Subscribed = dt.Rows[0]["Subscribed"].ToString(),
     
                };
            }
            return con;

        }

    }
}