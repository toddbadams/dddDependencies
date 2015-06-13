using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ddd.Core.Entities;

namespace ddd.Core.Queries
{
    public interface IQuery<T> where T : Entity
    {
        IQueryable<T> Queryable { get; set; }
        Task<T> SingleAsync();
        Task<IEnumerable<T>> ManyAsync();
    }
}