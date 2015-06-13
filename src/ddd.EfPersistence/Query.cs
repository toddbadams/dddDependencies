using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ddd.Core.Entities;
using ddd.Core.Queries;

namespace ddd.EfPersistence
{
    public class Query<T> : QueryBase<T> where T : Entity
    {
        public Query(IQueryable<T> query) : base(query)
        {
        }


        public override async Task<T> SingleAsync()
        {
            var result = await Queryable.FirstOrDefaultAsync();
            return result;
        }

        public override async Task<IEnumerable<T>> ManyAsync()
        {
            var result = await Queryable.ToArrayAsync();
            return result;
        }
    }
}
