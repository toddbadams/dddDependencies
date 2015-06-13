using System;
using System.Data.Entity;
using System.Linq;
using ddd.Core.Entities;
using ddd.Core.Persistence;
using ddd.Core.Queries;

namespace ddd.EfPersistence
{
    /// <summary>
    ///     Entity Framework based read-only repository.
    ///  Conventionv - Get for a single, Fetch for a collection
    /// </summary>
    public class EfReadOnlyRepository<T> : IReadOnlyRepository<T> where T : Entity
    {
        internal EfReadOnlyRepository(DbContext context)
        {
            // set repository context (holds entity framework info)
            Context = context;
            Table = Context.Set<T>();
        }

        #region Private Vars
        internal readonly DbContext Context; // the database context
        internal readonly IDbSet<T> Table; // the table we are working with
        private bool _disposed; // track if disposed
        #endregion

        #region public CRUD Methods
        /// <summary>
        ///     Query from the data store
        /// </summary>
        /// <returns>List of entites</returns>
        public IQuery<T> AsQuery()
        {
            // return table as a query
            return new Query<T>(Table.OfType<T>());
        }
        #endregion

        #region Dispose
        /// <summary>
        ///     dispose
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     dispose
        /// </summary>
        /// <param name="disposing">are we currently disposing</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            _disposed = true;
        }
        #endregion
    }
}