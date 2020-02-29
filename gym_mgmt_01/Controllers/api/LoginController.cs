using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Security;
using gym_mgmt_01.Helper_Code.Common;
using gym_mgmt_01.BAL.Master;

namespace gym_mgmt_01.Controllers.api
{
    [RoutePrefix("api/loginctrl")]
    public class LoginController : ApiController
    {
        [HttpPost, AllowAnonymous, Route("login")]
        public async Task<HttpResponseMessage> Login([FromBody]LoginRequest request)
        {
            var loginService = new LoginServices();
            LoginResponse response = await loginService.LoginAsync(request.username, request.password);
            if (response.Success)
            {
                FormsAuthentication.SetAuthCookie(response.Token, false);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPost, AllowAnonymous, Route("logout")]
        public void Signout()
        {
            FormsAuthentication.SignOut();

            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session.Abandon();
        }

        [HttpGet, Authorize(Roles = "admin"), Route("name")]
        public string GetMyName()
        {
            return "Saurabh sharma";
        }

    }
}