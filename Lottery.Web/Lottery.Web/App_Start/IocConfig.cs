using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Lottery.Service;
using Lottery.Service.IoC.Autofac;

namespace Lottery.Web
{
    #region IOC containers
    /* IOC Containers can resolve dependencies automatically
     * This container is AutoFac
     * In order for the container to be used anywhere it needs to be initialized and configured
     */
    #endregion
    // This is the configuration class for the AutoFac IOC Container
    public class IocConfig
    {
        // this is the container instance
        public static IContainer Container;
                             
        // These are the Initialize methods that are called in order for the container to be created
        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterDependencies(new ContainerBuilder()));
        }
        
        private static void Initialize(HttpConfiguration config, IContainer container)
        {
            // This initializer resolves dependencies for api controller classes
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        // This is the method where all dependencies are registered
        private static IContainer RegisterDependencies(ContainerBuilder builder)
        {
            //Register your Web API controllers.  
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Register the manager class with its interface
            builder.RegisterType<LotteryManager>()
                .As<ILotteryManager>()
                .InstancePerRequest();

            // Call a register module that is placed elsewhere and register the dependencies from there
            builder.RegisterModule(new ServiceModule());

            return builder.Build();
        }
    }
}