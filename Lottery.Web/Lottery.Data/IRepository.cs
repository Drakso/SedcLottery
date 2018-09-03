using System.Linq;
using Lottery.Data.Model;

namespace Lottery.Data
{
    // Interface for the repository to create a layer of abstraction so we can have a defined implementation of a repository without the logic
    // This helps us add multiple repositories with a same implementation but different logic inside them
    public interface IRepository<T> where T : IEntity
    {
        void Insert(T entity);
        void Delete(T entity);
        IQueryable<T> GetAll();
        T GetById(int id);
    }
}
