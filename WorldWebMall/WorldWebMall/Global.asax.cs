﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WorldWebMall.App_Start;
using System.Data.Entity;

using WorldWebMall.Models;

namespace WorldWebMall
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
            Database.SetInitializer<MallContext>(new DropCreateDatabaseIfModelChanges<MallContext>());
            //using this one instead of the commented out (null) solved "Invalid object name dbo.AspNet***" error
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
            //Database.SetInitializer<ApplicationDbContext>(null);
            Roles.RolesSetup();
            MapperConfig.Configure();
            GlobalConfiguration.Configuration.Formatters.JsonFormatter
            .SerializerSettings
            .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            
        }
    }
}
