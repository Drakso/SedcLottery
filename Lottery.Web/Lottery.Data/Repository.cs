using System.Data.Entity;
using System.Linq;
using Lottery.Data.Model;

namespace Lottery.Data
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected DbSet<T> DbSet;

        public Repository(DbContext dbContext)
        {
            DbSet = dbContext.Set<T>();
        }
        public void Insert(T entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public T GetById(int id)
        {
            return DbSet.Find(id);
        }
    }
}
