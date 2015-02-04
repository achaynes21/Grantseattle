using System.Web.Mvc;
using System.Reflection;
using System.Web.Http;
using System.Collections.Generic;
using System.Configuration;

using InventoryERP.Core;
using InventoryERP.Domain;
using InventoryERP.Data;
using InventoryERP.Data.Implementations;
using InventoryERP.Services;
using Autofac;
using Autofac.Integration.Mvc;
using InventoryERP.Data.Mapping;
using MongoDB.Driver;

namespace InventoryERP.Web
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            EntityMap.Register();

            SetAutofacWebAPIServices();
        }

        private static void SetAutofacWebAPIServices()
        {
            var configuration = GlobalConfiguration.Configuration;

            var builder = new ContainerBuilder();

            builder.RegisterType<MongoClient>().AsSelf().InstancePerRequest()
                .WithParameters(new List<NamedParameter> {
                    new NamedParameter("connectionString", App.Configurations.ConnectionString.Value)
                });
            builder.Register<MongoServer>(c => c.Resolve<MongoClient>().GetServer()).AsSelf().InstancePerRequest();
            builder.Register<MongoDatabase>(c => c.Resolve<MongoServer>().GetDatabase(App.Configurations.DatabaseName.Value)).AsSelf().InstancePerRequest();

            builder.RegisterGeneric(typeof(MongoRepository<>)).As(typeof(IRepository<>)).InstancePerRequest();

            var serviceAssembly = Assembly.GetAssembly(typeof(BaseService));

            builder.RegisterAssemblyTypes(serviceAssembly).Where(t => t.BaseType == typeof(BaseService)).AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();

            // Set the dependency resolver for MVC.
            var mvcResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(mvcResolver);
        }
    }
}
