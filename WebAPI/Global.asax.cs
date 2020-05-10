using DAL;
using DAL.Repositories;
using Managers;
using Room.Common.IOC;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //AreaRegistration.RegisterAllAreas();
            //GlobalConfiguration.Configure(WebApiConfig.Register);
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
            RegisterSimpleIoC();
            GlobalConfiguration.Configure(WebApiConfig.Register);
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
