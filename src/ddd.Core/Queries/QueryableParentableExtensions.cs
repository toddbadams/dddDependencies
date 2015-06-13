using System.Linq;
using ddd.Core.Entities;

namespace ddd.Core.Queries
{
    public static class QueryableParentableExtensions
    {
        public static IQuery<T> HasParent<T>(this IQuery<T> query, long parentId, ParentEntityType parentEntityType)
            where T : Entity, IParentable
        {

            query.Queryable = query.Queryable
                .Where(item => item.ParentId == parentId)
                .Where(item => item.ParentEntityType == parentEntityType);

            return query;
        }
    }
}