using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace gym_mgmt_01.Controllers
{
    [Route("api/qrcode")]
    public class APIController : ApiController
    {    
        [HttpGet]
        // GET: api/API
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        //    return "Demo";
        }

        [HttpPost]
        // GET: api/API/5
        public string Get(int id)
        {
            return "value";
        }
        [HttpGet]
        [ActionName("data")]
        public HttpResponseMessage GetData() {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        // POST: api/API
        public void Post([FromBody]string value)
        {
        }
        // PUT: api/API/5
        public void Put(int id, [FromBody]string value)
        {
        }
        // DELETE: api/API/5
        public void Delete(int id)
        {
        }
    }
}
