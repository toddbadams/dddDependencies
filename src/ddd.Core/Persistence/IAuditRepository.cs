using System.Collections.Generic;
using ddd.Core.Entities;

namespace ddd.Core.Persistence
{
    public interface IAuditRepository<in T> where T : Entity
    {
        void Delete(IUser user, IEnumerable<T> entities);
        void Update(IUser user, IEnumerable<T> entities);
        void Insert(IUser user, T entity);
    }
}