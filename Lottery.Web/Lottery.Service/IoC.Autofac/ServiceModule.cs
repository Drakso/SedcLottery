using System.Data.Entity;
using Autofac;
using Lottery.Data;
using Lottery.Data.Model;

namespace Lottery.Service.IoC.Autofac
{
    // A service module with configuration for registering the service dependencies
    // Dependencies in the modules are written the same as in the main configuration
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LotteryContext>()
                .As<DbContext>()
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(Repository<>))
                .As(typeof(IRepository<>));
        }
    }
}
