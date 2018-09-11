using System.Data.Entity;
using System.Linq;

namespace Lottery.Service.UoW
{
    #region Unit Of Work Pattern
    /* Unit of work pattern is a grouping of all operations and needed data in to one single class or transaction
     * The unit of work pattern usually goes with the repository pattern and instances of repositories are kept in it
     * The point is to have one point of entry for database manipulation that will take care of every operation including saving
     * The unit of work class implements the IUnitOfWork interface that implement the IDisposable
     * IDisposable allows us to dispose of the UnitOfWork class and its created instances after we are done using it
     * In our example we are not instancing the repositories because we have one generic repository
     * We get the database context from from the outside ( the dependency is resolved by the IOC Container )
     * The repositories only change the context but does not save it. The Commit method in this class actually saves all the changes done by the repository
     * This creates a transaction and if any of the repository changes to the context break, then no changes will be written in the database
     */
    #endregion
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
