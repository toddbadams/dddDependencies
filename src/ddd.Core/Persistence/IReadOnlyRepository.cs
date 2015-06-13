using System;
using ddd.Core.Entities;
using ddd.Core.Queries;

namespace ddd.Core.Persistence
{
    /// <summary>
    ///     Represent an readonly repository of IRna objects.
    /// </summary>
    public interface IReadOnlyRepository<T> : IDisposable where T : Entity
    {
        /// <summary>
        ///  Gets the Query from the data store
        /// </summary>
        /// <returns>List of entites</returns>
        IQuery<T> AsQuery();     
    }
}