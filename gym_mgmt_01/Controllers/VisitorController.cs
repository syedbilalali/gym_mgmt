using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace gym_mgmt_01.Controllers
{    
    
    public class VisitorController : ApiController
    {   

        [HttpGet]
        public string Get() {
            return "Welecome Demo !!!";
        }
        [HttpGet]
        [Route("api/getA")]
        public string GetA() {
            return "Welecome Demo !!!";
        }
        [HttpPost]
        [Route("api/checkin")]
        public void Post([FromBody] string value) {
            var data = value;
        }
    }
}
