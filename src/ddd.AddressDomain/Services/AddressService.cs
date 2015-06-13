using System;
using System.Threading.Tasks;
using ddd.Core.Entities;
using ddd.Core.Entities.AddressDomain;
using ddd.Core.Logging;
using ddd.Core.Persistence;
using ddd.Core.Queries;

namespace ddd.AddressDomain.Services
{
    public class AddressService : IAddressService
    {
        private readonly IReadOnlyRepository<Address> _addressReadOnlyRepository;
        private readonly ILog _log;

        public AddressService(IReadOnlyRepository<Address> addressReadOnlyRepository,
            ILog log)
        {
            _addressReadOnlyRepository = addressReadOnlyRepository;
            _log = log;
        }

        public async Task<Address> Get(long parentId, ParentEntityType parentEntityType)
        {
            var m = string.Format("AddressService.Get(parentId={0},ParentEntityType={1})", parentId, parentEntityType);
            try
            {
                _log.Debug(m);
                var result = await _addressReadOnlyRepository.AsQuery()
                    .HasParent(parentId, parentEntityType)
                    .SingleAsync();
                return result;
            }
            catch (Exception ex)
            {
                _log.Error(m,ex);
                throw;
            }
        }
    }
}
