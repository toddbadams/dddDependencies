using System.Linq;
using ddd.Core.Entities;

namespace ddd.Core.Queries
{
    public static class QueryableEntityExtensions
    {

        /// <summary>
        /// Return a paged set of entities
        /// </summary>
        public static IQuery<T> Paged<T>(this IQuery<T> query, int start, int limit) 
            where T : Entity
        {
            query.Queryable = query.Queryable
                .Skip(start - 1)
                .Take(limit);

            return query;
        }

        /// <summary>
        /// Return only active entities
        /// </summary>
        public static IQuery<T> IsDeleted<T>(this IQuery<T> query) 
            where T : Entity
        {
            query.Queryable = query.Queryable
                .Where(item => item.IsDeleted);

            return query;
        }

        /// <summary>
        /// Return only inactive entities
        /// </summary>
        public static IQuery<T> IsNotDeleted<T>(this IQuery<T> query) 
            where T : Entity
        {
            query.Queryable = query.Queryable
                .Where(item => !item.IsDeleted);

            return query;
        }

        /// <summary>
        /// Check if an id exists
        /// </summary>
        public static IQuery<T> WithId<T>(this IQuery<T> query, object id) 
            where T : Entity
        {
            query.Queryable = query.Queryable
                .Where(item => item.Id == id);

            return query;
        }
    }
}