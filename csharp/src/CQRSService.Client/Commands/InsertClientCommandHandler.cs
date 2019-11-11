using CQRSService.Client.CQRSService.Domain.Commands;
using CQRSService.Client.Storage;
using CQRSService.Domain.Commands;
using CQRSService.Domain.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSService.Client.Commands
{
    public class InsertClientCommandHandler : ICommandHandler<InsertClientCommand>
    {
        private readonly IStorage<Client> _clientStorage;
        private readonly IEventBus _eventBus;

        public InsertClientCommandHandler(IStorage<Client> clientStorage, IEventBus eventBus)
        {
            _clientStorage = clientStorage;
            _eventBus = eventBus;
        }
        public async Task<Unit> Handle(InsertClientCommand request, CancellationToken cancellationToken)
        {
            var client = new Client(request.Name);
            await _clientStorage.Add(client);
            await _eventBus.Publish(client.PendingEvents.ToArray());
            return Unit.Value;
        }
    }
}
