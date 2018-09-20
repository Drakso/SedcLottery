using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Lottery.Data.Model
{
    public class LotteryContext : DbContext
    {
        public LotteryContext() : 
            base("Data Source=DESKTOP-QKEPS8P;Initial Catalog=LotteryDb;User ID=dbUser;Password=P@ssw0rd")
            //base("Server=tcp:lottery-db-189.database.windows.net,1433;Initial Catalog=LotteryDB;Persist Security Info=False;User ID=lottery-user;Password=P@ssw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
        {
        }

        public virtual DbSet<Code> Codes { get; set; }
        public virtual DbSet<UserCode> UserCodes { get; set; }
        public virtual DbSet<Award> Awards { get; set; }
        public virtual DbSet<UserCodeAward> UserCodeAwards { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
