using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ddd.Core.Entities;

namespace ddd.Core.Queries
{
    public abstract class QueryBase<T> : IQuery<T> where T : Entity
    {
        public IQueryable<T> Queryable { get; set; }

        protected QueryBase(IQueryable<T> query)
        {
            Queryable = query;
        }


        public abstract Task<T> SingleAsync();
        public abstract Task<IEnumerable<T>> ManyAsync();
    }
}
