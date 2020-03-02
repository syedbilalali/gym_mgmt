using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace gym_mgmt_01
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {   
            config.MapHttpAttributeRoutes();
           config.Formatters.XmlFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded"));
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}