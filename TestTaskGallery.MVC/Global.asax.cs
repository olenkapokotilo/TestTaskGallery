using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;

namespace TestTaskGallery.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        internal static MapperConfiguration MapperConfigurationMVC { get; private set; }
        internal static MapperConfiguration MapperConfigurationDA { get; private set; }

        protected void Application_Start()
        {
            MapperConfigurationMVC = MapperConfig.GetConfiguration();
            MapperConfigurationDA = DataAccess.Startup.MapperConfig.GetConfiguration();
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents(); 
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //DataAccess.Startup.MapperConfig.GetConfiguration().RegisterMapping();
            //MappingConfiguration.RegisterMapping();
        }
    }
}
