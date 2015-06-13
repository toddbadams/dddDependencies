using System.Linq;
using ddd.Core.Entities;

namespace ddd.Core.Queries
{
    public static class QueryableEmailExtensions
    {
        /// <summary>
        /// Return entities with a given email
        /// </summary>
        public static IQuery<T> WithEmail<T>(this IQuery<T> query, string email)
            where T : Entity, IEmail
        {
            query.Queryable = query.Queryable
                .Where(item => item.Email == email);

            return query;
        }
    }
}