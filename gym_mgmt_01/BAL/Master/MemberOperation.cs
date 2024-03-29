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
    public class MemberOperation
    {
        DataAdapter da = new DataAdapter();
        public MemberOperation() { 
        }
        public void AddMemeber(Member mb ) {
            //Insert Command 
            string command = "INSERT INTO dbo.Member(FirstName, LastName , DOB,Gender  , Note , MemberType, ImgURL) VALUES(@FirstName, @LastName ,@DOB,  @Gender ,@Note , @MemberType , @ImgURL)";
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@FirstName" , mb.FirstName);
            param[1] = new SqlParameter("@LastName" , mb.LastName);
            param[2] = new SqlParameter("@DOB", mb.DOB);
            param[3] = new SqlParameter("@Gender", mb.Gender);
            param[4] = new SqlParameter("@Note", (mb.note == null) ? "" : mb.note) ;
            param[5] = new SqlParameter("@MemberType", mb.MemberType);
            param[6] = new SqlParameter("@ImgURL" , (mb.ImagePath == null) ? "" : mb.ImagePath);
            da.Insert(param , command);
        }
        public void UpdateMember(Member mb) {
            string command = "UPDATE dbo.Member SET FirstName=@FirstName, LastName=@LastName , DOB=@DOB, Gender=@Gender  , Note=@Note , MemberType=@MemberType, ImgURL=@ImgURL WHERE Id=@Id";
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@Id", mb.Id);
            param[1] = new SqlParameter("@FirstName", mb.FirstName);
            param[2] = new SqlParameter("@LastName", mb.LastName);
            param[3] = new SqlParameter("@DOB", DateTime.Parse(mb.DOB).ToString("yyyy-MM-dd"));
            param[4] = new SqlParameter("@Gender", mb.Gender);
            param[5] = new SqlParameter("@Note", (mb.note == null) ? "" : mb.note);
            param[6] = new SqlParameter("@MemberType", mb.MemberType);
            param[7] = new SqlParameter("@ImgURL", (mb.ImagePath == null) ? "" : mb.ImagePath);
            da.Insert(param, command);
        }
        public void DeleteMember(int id) {

            string command = "";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id",id);
            da.Insert(param , command);
        }
        public DataTable getMember() {
            DataTable dt = new DataTable();
            string command = "SELECT * FROM dbo.Member Order by Id DESC";
            return da.FetchAll(command);
        }
        public DataTable getMemberWithMembership() {
            DataTable dt = new DataTable();
            string command = "SELECT mr.Id,mr.FirstName ,mr.LastName , mr.Gender , mr.DOB  , mr.ImgURL , ISNULL(mbr.Id, 0) as MId,ISNULL(mbr.Name,'None') as Name ,ISNULL(mbr.Amount, 0.00) as Amount  FROM Member mr  LEFT JOIN Subscriptions sbs ON mr.Id = sbs.MemberID LEFT JOIN Membership mbr ON mbr.Id = sbs.MembershipID ORDER BY Id DESC";
            return da.FetchAll(command);
        }
        public List<MemberDetails> getMemberWithMembershipAll() {
            DataTable dt = new DataTable();
            string command = "SELECT mr.Id,mr.FirstName ,mr.LastName , mr.Gender , mr.DOB  , mr.ImgURL , ISNULL(mbr.Id, 0) as MId,ISNULL(mbr.Name,'None') as Name , ISNULL(mbr.Amount, 0.00) as Amount , ISNULL(sbs.Id , 0) As SubscriptionsID  FROM Member mr  LEFT JOIN Subscriptions sbs ON mr.Id = sbs.MemberID INNER JOIN Membership mbr ON mbr.Id = sbs.MembershipID ORDER BY Id DESC";
            dt = da.FetchAll(command);
            List<MemberDetails> md = new List<MemberDetails>();
            if (dt.Rows.Count > 0) {
                md = (from DataRow dr in dt.Rows
                      select new MemberDetails()
                      {
                          Id = int.Parse(dr["Id"].ToString()),
                          FirstName = dr["FirstName"].ToString(),
                          LastName = dr["LastName"].ToString(),
                          Gender = dr["Gender"].ToString(),
                          DOB = dr["DOB"].ToString(),
                          ImagePath = dr["ImgURL"].ToString(),
                          MId = int.Parse(dr["MId"].ToString()),
                          Name = dr["Name"].ToString(),
                          SId = int.Parse(dr["SubscriptionsID"].ToString()),
                          Amount = decimal.Parse(dr["Amount"].ToString())

                      }
                  ).ToList();
            }
            return md;
        }
        public List<Member> getAllMembers() {
            DataTable dt = new DataTable();
            string command = "SELECT * FROM dbo.Member";
            dt = da.FetchAll(command);
            List<Member> data = new List<Member>();
            if (dt.Rows.Count > 0) {
                data = (from DataRow dr in dt.Rows select new Member() {
                    Id = int.Parse(dr["Id"].ToString()),
                    FirstName = dr["FirstName"].ToString(),
                    LastName = dr["LastName"].ToString(),
                    DOB = dr["DOB"].ToString(),
                    Gender = dr["Gender"].ToString(),
                    note = dr["Note"].ToString(),
                    MemberType = dr["MemberType"].ToString(),
                    ImagePath = dr["ImgURL"].ToString()
                }).ToList();
            }
            return data;
        }
        public string getMemberID() {
            DataAdapter da = new DataAdapter();
            int lastID = da.getLastID("Id", "dbo.Member");
            if (lastID != 0)
            {
                lastID++;
            }
            return lastID.ToString();
        }
        public DataTable getMember(string name)
        {
            DataTable dt = new DataTable();
            string command = "SELECT *  FROM dbo.Member WHERE dbo.Member.FirstName LIKE '%" + name +"%' ";
            //SqlParameter[] param = new SqlParameter[1];
          //  param[0] = new SqlParameter("@Name" , name);
           /// return da.FetchByParameter(param , command);
            return da.FetchAll(command);
        }
        public Member getMember(int? id) {
            
            DataTable dt = new DataTable();
            string command = "SELECT * FROM dbo.Member WHERE dbo.Member.Id=@Id";
            SqlParameter[] param = new SqlParameter[1];
            Member mem = new Member();
            param[0] = new SqlParameter("@Id", id);
            dt = da.FetchByParameter(param, command);
            if (dt.Rows.Count > 0) {
                mem = new Member()
                {
                    Id = int.Parse(dt.Rows[0]["Id"].ToString()),
                    FirstName = dt.Rows[0]["FirstName"].ToString(),
                    LastName = dt.Rows[0]["LastName"].ToString(),
                    DOB = dt.Rows[0]["DOB"].ToString(),
                    Gender = dt.Rows[0]["Gender"].ToString(),
                    note = dt.Rows[0]["Note"].ToString(),
                    MemberType = dt.Rows[0]["MemberType"].ToString(),
                    ImagePath = dt.Rows[0]["ImgURL"].ToString(),
                    QRUri = dt.Rows[0]["QRURL"].ToString(),
                   
                };
            }
            return mem;
            
        }
        public bool saveQRCode(int Id , string ImageURI) {

            string command = "UPDATE dbo.Member SET QRURL=@QRURL WHERE Id=@Id";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Id", Id);
            param[1] = new SqlParameter("@QRURL" , ImageURI);
          
            return da.Insert(param, command);
        }


    }
}