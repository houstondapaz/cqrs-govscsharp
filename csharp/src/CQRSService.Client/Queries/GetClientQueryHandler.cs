using CQRSService.Client.Domain.Queries;
using CQRSService.Client.Storage;
using CQRSService.Domain.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSService.Client.Queries
{
    public class GetClientQueryHandler : IQueryHandler<GetClientQuery, Client>
    {
        private readonly IStorage<Client> _clientStorage;

        public GetClientQueryHandler(IStorage<Client> clientStorage) => _clientStorage = clientStorage;
        public Task<Client> Handle(GetClientQuery query, CancellationToken cancellationToken)
            =>  _clientStorage.GetOne(query.Id);
    }
}
