using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Lottery.Data.Model
{
    // An Entity Framework context class in order for entity framework to know what to map from our code
    public class LotteryContext : DbContext
    {
        // We create an empty constructor but we call the parent constructor that requests for a database by name, so we are giving it one here
        public LotteryContext() : 
            base("LotteryDb")
            //base("Server=tcp:lottery-db-189.database.windows.net,1433;Initial Catalog=LotteryDB;Persist Security Info=False;User ID=lottery-user;Password=P@ssw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
        {
        }

        // Sets of data from all the entities that we need
        public virtual DbSet<Code> Codes { get; set; }
        public virtual DbSet<UserCode> UserCodes { get; set; }
        public virtual DbSet<Award> Awards { get; set; }
        public virtual DbSet<UserCodeAward> UserCodeAwards { get; set; }

        // A method that will run before this model is finished creating
        // We override it to add our own configuration
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Remove the pluralizing configuration on the tables ( it would not add s at the end of plural form of entities, Ex: user -> users )
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
