using ddd.Core.Entities;

namespace ddd.Core.Queries
{
    public interface IViewProvider
    {
        IQuery<T> Query<T>(string queryString) where T : Entity;
    }
}