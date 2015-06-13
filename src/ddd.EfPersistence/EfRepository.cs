using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ddd.Core.Entities;
using ddd.Core.Persistence;

namespace ddd.EfPersistence
{
    /// <summary>
    ///     Entity Framework based read-write repository.
    /// </summary>
    public sealed class EfRepository<T> : EfReadOnlyRepository<T>, IRepository<T> where T : Entity
    {
        private readonly IAuditRepository<T> _auditRepository;

        public EfRepository(DbContext context, IAuditRepository<T> auditRepository = null)
            : base(context)
        {
            _auditRepository = auditRepository;
        }

        #region public CRUD Methods
        /// <summary>
        /// Create an entity in the data store
        /// </summary>
        /// <param name="user">user used to capture in audit</param>
        /// <param name="entity">entity to create</param>
        public T Insert(T entity, IUser user = null)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            // add entity to data store
            Table.Add(entity);

            // audit
            if (_auditRepository != null) _auditRepository.Insert(user, entity);


            return entity;
        }

        /// <summary>
        /// Update entities in the data store
        /// </summary>
        /// <param name="user">user used to capture in audit</param>
        /// <param name="entities">entities to update</param>
        public void Update(IEnumerable<T> entities, IUser user = null)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            // process unit of work prior to update in data store
            var enumerable = entities as T[] ?? entities.ToArray();
            foreach (var entity in enumerable)
            {
                Table.Attach(entity);
                Context.Entry((Entity)entity).State = EntityState.Modified;
            }

            // audit
            if (_auditRepository != null) _auditRepository.Update(user, enumerable);
        }

        /// <summary>
        /// Delete an entities that match the domainFilter from the data store
        /// </summary>
        /// <param name="user">user id used to capture in audit</param>
        /// <param name="entities">entities to delete</param>
        public void Delete(IEnumerable<T> entities, IUser user = null)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            // loop and delete
            var enumerable = entities as T[] ?? entities.ToArray();
            foreach (var entity in enumerable)
            {
                if (Context.Entry(entity).State == EntityState.Detached)
                    Table.Attach(entity);

                Table.Remove(entity);
            }

            // audit
            if (_auditRepository != null) _auditRepository.Delete(user, enumerable);
        }

        /// <summary>
        /// Save all changes to the data store
        /// </summary>
        /// <returns>The number of objects written to the underlying database</returns>
        public async Task<int> SaveChangesAsync()
        {
            // update the data store
            var results = await Context.SaveChangesAsync();

            return results;
        } 
        #endregion

    }
}