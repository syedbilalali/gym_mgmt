using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace gym_mgmt_01.Helper_Code.Common
{
    public class adminPrincipalProvider
    {
        public IPrincipal createPrincipal(string userName, string role)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                var identity = new GenericIdentity(userName);
                IPrincipal principal = new GenericPrincipal(identity, new[] { role });
                return principal;
            }
            else { return null; }
        }
    }
}