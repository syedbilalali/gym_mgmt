using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace gym_mgmt_01.Helper_Code.Common
{
    public class UniqueRoute : Route
    {
        private readonly bool isUnique;

        public UniqueRoute(string uri, object defaults)
           : base(uri, new RouteValueDictionary(defaults), new MvcRouteHandler())
        {
            isUnique = uri.Contains("guid");

            DataTokens = new RouteValueDictionary();
        }

        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            var routeData = base.GetRouteData(httpContext);
            if (routeData == null)
                return null;

            if (!routeData.Values.ContainsKey("guid") ||
           routeData.Values["guid"].ToString() == "")
                routeData.Values["guid"] = Guid.NewGuid().ToString();

            return routeData;
        }

        public override VirtualPathData GetVirtualPath
        (RequestContext requestContext, RouteValueDictionary values)
        {
            return !isUnique ? null : base.GetVirtualPath(requestContext, values);
        }
    }
}