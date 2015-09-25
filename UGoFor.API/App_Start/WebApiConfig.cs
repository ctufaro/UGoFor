﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Routing;
using System.Net.Http.Headers;

namespace UGoFor.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                        "PostBlobUpload",
                        "blobs/upload",
                        new { controller = "Blobs", action = "PostBlobUpload" },
                        new { httpMethod = new HttpMethodConstraint("POST") }
                    );

            config.Routes.MapHttpRoute(
                "GetBlobDownload",
                "blobs/{blobId}/download",
                new { controller = "Blobs", action = "GetBlobDownload" },
                new { httpMethod = new HttpMethodConstraint("GET") }
            );

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}
