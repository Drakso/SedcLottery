using System.Data.Entity;
using System.Linq;
using Lottery.Data.Model;

namespace Lottery.Data
{
    #region Explanation of IRepository<T>
    /*
    Repository pattern:
        Benefits: 
        - Better organised and readable code by having all querying for entities from database packed in one place
        - Have a more loosely coupled code
        - Have a flexible platform for different ORMs access to database
        How it works:
        - The repository keeps all the methods for accessing and manipulating a DataBase
        - When we want to access the database from somewhere we create instance of the repository or call it by other means ( UnitOfWork ) and call the methods that are given
        - Repositories can be created for different entities or different logical models
        - Can also be generic and accept the model from outside
        This Repository:
        - This repository is generic meaning that it will accept an entity and will fit that description to the methods automatically. The input entity is taking the place of the T. 
        - We have the basic crud methods for manipulating our database
        - It does not have saving changes in the database because it will be combined with the unit of work pattern and the saving would be done there to create a transaction like saving system
        - It is a generic repository meaning that it accepts a type and executes the methods with only that type of entity
        - The [ where T : class, IEntity ] means that the type that is entered MUST implement IEntity ( inherit from it ) and be a class. This is done to prevent other entities other than ours from working with the repository 
         */
    #endregion
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        // This is the DbSet from the context for the entity that will be passed
        // Ex. If we add Code as T, the DbSet will be the Code data from the database
        protected DbSet<T> DbSet;

        // Here we create a constructor that accepts a DbContext
        // This dbContext is the one that we use and from which we can extract the DbSet with the Data we need about the T entity ( The entity that is passed )
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

        // We use IQueryable so we can send expression through Linq and Entity framework and execute statements on the database like WHERE statements, instead of using IEnumerable or IList where we will wait the database to return ALL data and then filter the data with our where statements.
        // More info: https://www.youtube.com/watch?v=RYvuaU47h2w
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
