using Autofac;
using Autofac.Integration.WebApi;
using BookStore.Repository;
using BookStore.Services;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;

namespace BookStore.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<DbRepository>().As<IDbRepository>();
            builder.RegisterType<BookService>().As<IBookService>();
            builder.Register(c => LogManager.GetLogger(typeof(object))).As<ILog>();
            builder.RegisterType<CustomersService>().As<ICustomersService>();

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
