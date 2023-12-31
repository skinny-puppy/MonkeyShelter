﻿using MonkeyShelter.Common;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MonkeyShelter
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            config.DependencyResolver = CastleHelper.GetDependencyResolver();


            // Cors
            var cors = new EnableCorsAttribute("*", "*", "*"); // origins, headers, methods
            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings
                       .Add(new System.Net.Http.Formatting.RequestHeaderMapping("Accept",
                              "text/html",
                              StringComparison.InvariantCultureIgnoreCase,
                              true,
                              "application/json"));
        }
    }
}
