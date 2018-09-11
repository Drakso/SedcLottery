using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace Lottery.Data.Model.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<LotteryContext>
    {
        // This is the configuration method that manages the entity framework communication with the database
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        // This is a seed method. This method runs whenever a database is created using the Code First aproach
        // We usually add data that we want to have in the database when it is created like default or admin user, or like in our case set of codes
        protected override void Seed(LotteryContext context)
        {
            var codes = new List<Code>
            {
                new Code {CodeValue = "CC8899", IsWinning = true},
                new Code {CodeValue = "CC7799", IsWinning = false},
                new Code {CodeValue = "CC6699", IsWinning = false},
                new Code {CodeValue = "CC5599", IsWinning = true}
            };

            context.Codes.AddRange(codes);

            var awards = new List<Award>
            {
                new Award
                {
                    AwardName = "Beer",
                    AwardDescription = "You won a beer",
                    Quantity = 100,
                    RuffledType = (byte) RuffledType.Immediate
                },
                new Award
                {
                    AwardName = "iPhoneX",
                    AwardDescription = "You won an iPhoneX",
                    Quantity = 2,
                    RuffledType = (byte) RuffledType.PerDay
                },
                new Award
                {
                    AwardName = "VW Polo",
                    AwardDescription = "You won a Polo",
                    Quantity = 1,
                    RuffledType = (byte) RuffledType.Final
                }

            };

            context.Awards.AddRange(awards);

            context.SaveChanges();
        }
    }
}
