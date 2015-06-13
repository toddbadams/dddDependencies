using System.Threading.Tasks;
using ddd.Core.Entities;
using ddd.Core.Entities.AddressDomain;

namespace ddd.AddressDomain.Services
{
    public interface IAddressService
    {
        Task<Address> Get(long parentId, ParentEntityType parentEntityType);
    }
}