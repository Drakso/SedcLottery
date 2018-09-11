using System;

namespace Lottery.Service.UoW
{
    // This is the interface for our UnitOfWork class
    // It has only the commit method
    // If we were creating a UnitOfWork class that keeps track of the repositories than we would have properties of the repositories here as well
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Commits all changes
        /// </summary>
        void Commit();
    }
}
