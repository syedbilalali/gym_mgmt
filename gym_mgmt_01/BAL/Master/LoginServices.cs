using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;

namespace gym_mgmt_01.BAL.Master
{
    public class LoginServices
    {
        public async Task<LoginResponse> LoginAsync(string userName, string password)
        {
            LoginResponse responseLoginAsync = new LoginResponse();

            if (userName == "saurabh@admin.com" && password == "password\n")
            {
                responseLoginAsync.Success = true;
                responseLoginAsync.Token = userName;
            }
            else
            {
                responseLoginAsync.Success = false;
                responseLoginAsync.Token = string.Empty;
            }

            return responseLoginAsync;
        }
    }
}