﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace TokenAuth
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");

            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                //These headers are handling the "pre-flight" OPTIONS call sent by the browser
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept, BearerAuth");
                HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
                HttpContext.Current.Response.End();
            }
        }
    }
}
