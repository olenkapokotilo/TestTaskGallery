using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using Newtonsoft.Json;
using TestTaskGallery.API.Mapper;

namespace TestTaskGallery.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        internal static MapperConfiguration MapperConfigurationAPI { get; private set; }
        internal static MapperConfiguration MapperConfigurationDA { get; private set; }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            MapperConfigurationAPI = MapperConfig.GetConfiguration();
            MapperConfigurationDA = DataAccess.Startup.MapperConfig.GetConfiguration();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
