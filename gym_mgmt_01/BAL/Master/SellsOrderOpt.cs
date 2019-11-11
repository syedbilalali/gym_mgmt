using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gym_mgmt_01.Models;
using gym_mgmt_01.DAL;
using System.Data;
using System.Data.SqlClient;

namespace gym_mgmt_01.BAL.Master
{
    public class SellsOrderOpt
    {
        DataAdapter da = new DataAdapter();
        DataTable dt = new DataTable();
        public SellsOrderOpt() {
        }
        public void addSellsOrder(SellsOrder so) {
            
        }
        public string getLastInvoiceID()
        {   
            char pad = '0';
            char pad1 = '#';
            int a =  da.getLastID("Invoice_number", "dbo.SellsOrder");
            string b = a.ToString();
            string c =  b.PadLeft(4 , pad);
            return c.PadLeft(1, pad1);
        }
    }
}