using System;
using System.IO;
using Lottery.Data;
using Lottery.Data.Model;
using Lottery.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Lottery.RaffleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = Configure();

            var lotteryManager = serviceProvider.GetService<ILotteryManager>();
            var configuration = serviceProvider.GetService<IConfigurationRoot>();

            var finalRaffle = DateTime.Parse(configuration.GetSection("FinalRaffle").Value);

            if (DateTime.Now.Date <= finalRaffle)
            {
                lotteryManager.GiveAwards(RaffledType.PerDay);
            }

            if (DateTime.Now.Date == finalRaffle)
            {
                lotteryManager.GiveAwards(RaffledType.Final);
            }
        }

        static IServiceProvider Configure()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true);

            IConfigurationRoot configuration = builder.Build();

            var serviceProvider = new ServiceCollection()
                .AddSingleton(provider => configuration)
                .AddSingleton<DbContext, LotteryContext>()
                .AddSingleton<ILotteryManager, LotteryManager>()
                .AddSingleton(typeof(IRepository<>), typeof(Repository<>))
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
