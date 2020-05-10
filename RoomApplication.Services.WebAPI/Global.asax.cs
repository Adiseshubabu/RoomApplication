using RoomApplication.Services.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using SimpleInjector.Integration.WebApi;
using RoomApplication.Services.BusinessManagers.Master;
using RoomApplication.Services.DAL.Repositories;
using RoomApplication.Common.IOC;

namespace RoomApplication.Services.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RegisterSimpleIoC();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void RegisterSimpleIoC()
        {
            Container container = new Container();
            container.Options.AutowirePropertiesWithAttribute<SimpleIoCPropertyInjectAttribute>();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Register(typeof(IConnectionFactory), typeof(ConnectionFactory));
          
            container.Register(typeof(IMasterManager), typeof(MasterManager));

            container.Register(typeof(IDynamicRepository), typeof(DynamicRepository));


            //container.Verify();


            //Web Api dependency resolver setting.
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}

