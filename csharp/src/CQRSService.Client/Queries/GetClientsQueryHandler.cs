using CQRSService.Client.Domain.Queries;
using CQRSService.Client.Storage;
using CQRSService.Domain.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSService.Client.Queries
{
    public class GetClientsQueryHandler : IQueryHandler<GetClientsQuery, IEnumerable<Client>>
    {
        private readonly IStorage<Client> _clientStorage;

        public GetClientsQueryHandler(IStorage<Client> clientStorage) => _clientStorage = clientStorage;
        public Task<IEnumerable<Client>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
            => _clientStorage.GetAll();
    }
}
