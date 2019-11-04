using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace gym_mgmt_01.DAL
{
    public class ConnectionString
    {
        public ConnectionString() { 
        }
        public string connect()
        {   
            // local , Default
            return ConfigurationManager.ConnectionStrings["local"].ConnectionString;
        }
    }
  
}