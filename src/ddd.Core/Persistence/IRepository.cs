using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ddd.Core.Entities;

namespace ddd.Core.Persistence
{
    /// <summary>
    ///     Represents a read/write repository of IRna objects.
    /// </summary>
    public interface IRepository<T> : IReadOnlyRepository<T> where T : Entity
    {
        /// <summary>
        /// Create an entity in the data store
        /// </summary>
        /// <param name="user">user id used to capture in audit</param>
        /// <param name="entity">entity to create</param>
        T Insert(T entity, IUser user = null);

        /// <summary>
        /// Update entities in the data store
        /// </summary>
        /// <param name="user">user id used to capture in audit</param>
        /// <param name="query">enumerable set of entities</param>
        void Update(IEnumerable<T> query, IUser user = null);

        /// <summary>
        /// Delete an entities that match the domainFilter from the data store
        /// </summary>
        /// <param name="user">user id used to capture in audit</param>
        /// <param name="query">enumerable set of entities</param>
        void Delete(IEnumerable<T> query, IUser user = null);

        /// <summary>
        /// Save all changes to the data store
        /// </summary>
        /// <returns>The number of objects written to the underlying database</returns>
        Task<int> SaveChangesAsync();
    }
}