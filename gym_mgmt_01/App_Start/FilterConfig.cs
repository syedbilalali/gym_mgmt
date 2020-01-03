using System.Web;
using System.Web.Mvc;
using gym_mgmt_01.Helper_Code.Common;

namespace gym_mgmt_01
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
           // filters.Add(new AuthorizationPrivilegeFilter());
        
        }
    }
}
