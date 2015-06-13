using System.Data.Entity;
using System.Linq;
using ddd.Core.Entities;
using ddd.Core.Queries;

namespace ddd.EfPersistence
{
    public class ViewProvider : IViewProvider
    {
        private readonly DbContext _context;

        public ViewProvider(DbContext context)
        {
            _context = context;
        }

        public IQuery<T> Query<T>(string queryString)
        where T : Entity
        {
            var queryObject = _context.Database.SqlQuery<T>(queryString).AsQueryable();
            var result = new Query<T>(queryObject);

            return result;
        }
    }
}
