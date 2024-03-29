﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PS_APM_WebAPI_266
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            // 06/01/2021 03:18 am - SSN - [20210531-2330] - [005] - Validating callers

            string key = ConfigurationManager.AppSettings["InstrumentationKey"];
            Microsoft.ApplicationInsights.Extensibility.TelemetryConfiguration.Active.InstrumentationKey = key;


        }
    }
}
