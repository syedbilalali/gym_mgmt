using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Http;

namespace gym_mgmt_01.Models
{
    public class Message
    {
        // public string msg;
        // public HttpStatusCode code;
        //  public string status;
        public object data;

        public Message(Object data)
        {
            this.data = data;
        }
        public Message(HttpStatusCode code, string msg, string status)
        {
            //   this.code = code;
            //   this.msg = msg;
            //   this.status = status;
        }
        public Message(HttpStatusCode code, string msg, string status, object data)
        {
            //   this.code = code;
            //  this.msg = msg;
            //   this.status = status;
            this.data = data;
        }
    }
}