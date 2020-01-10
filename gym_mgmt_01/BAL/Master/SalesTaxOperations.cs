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
    public class SalesTaxOperations
    {
        DataAdapter da = new DataAdapter();
        public void AddSalesTax(SalesTax tax)
        {
            string command = "INSERT INTO dbo.SalesTax(SalesTaxName,SalesTaxValue) VALUES(@SalesTaxName,@SalesTaxValue)";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@SalesTaxName", tax.SalesTaxName);
            param[1] = new SqlParameter("@SalesTaxValue", tax.SalesTaxValue);
            da.Insert(param, command);
        }

        public void updateSalesTax(SalesTax tax)
        {
            string command = "UPDATE SalesTax SET SalesTaxName=@SalesTaxName,SalesTaxValue=@SalesTaxValue WHERE Id=@Id";
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Id", tax.Id);
            param[1] = new SqlParameter("@SalesTaxName", tax.SalesTaxName);
            param[2] = new SqlParameter("@SalesTaxValue", tax.SalesTaxValue);

            da.Insert(param, command);
        }

        public DataTable getSalesTax()
        {
            string command = "SELECT * FROM dbo.SalesTax Order By Id DESC";
            return da.FetchAll(command);
        }

        public DataTable getSalesTaxById(int id)
        {
            string command = "SELECT * FROM dbo.SalesTax WHERE Id=@Id";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id", id);
            return da.FetchByParameter(param, command);
        }
        public SalesTax getSalesTaxByIdObj(int id) {
            string command = "SELECT * FROM dbo.SalesTax WHERE Id=@Id";
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id", id);
            SalesTax st = new SalesTax(); 
            dt =  da.FetchByParameter(param, command);
            if (dt.Rows.Count > 0) {
                st = new SalesTax()
                {
                    Id = int.Parse(dt.Rows[0]["Id"].ToString()),
                    SalesTaxName = dt.Rows[0]["SalesTaxName"].ToString(),
                    SalesTaxValue = dt.Rows[0]["SalesTaxValue"].ToString()
                };
            }
            return st;
        }
        public bool deleteSalesTaxById(int Id)
        {
            string command = "DELETE FROM dbo.SalesTax WHERE Id=@Id";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id", Id);
            return da.Insert(param, command);
        }
        public List<SalesTax> getAllSalesTax()
        {
            string command = "SELECT * FROM dbo.SalesTax";
            List<SalesTax> st = new List<SalesTax>();
            DataTable dt = new DataTable();
            dt = da.FetchAll(command);
            if (dt.Rows.Count > 0)
            {
                st = (from DataRow dr in dt.Rows
                      select new SalesTax()
                      {
                          Id = int.Parse(dr["Id"].ToString()),
                          SalesTaxName = dr["SalesTaxName"].ToString(),
                          SalesTaxValue = dr["SalesTaxValue"].ToString(),

                      }).ToList();
            }
            return st;
        }
    }
}