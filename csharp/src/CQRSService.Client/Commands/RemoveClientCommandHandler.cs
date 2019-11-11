using CQRSService.Client.CQRSService.Domain.Commands;
using CQRSService.Client.Storage;
using CQRSService.Domain.Commands;
using CQRSService.Domain.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSService.Client.Commands
{
    public class RemoveClientCommandHandler : ICommandHandler<RemoveClientCommand>
    {
        private readonly IStorage<Client> _clientStorage;
        private readonly IEventBus _eventBus;

        public RemoveClientCommandHandler(IStorage<Client> storageClient, IEventBus eventBus)
        {
            _clientStorage = storageClient;
            _eventBus = eventBus;
        }
        public async Task<Unit> Handle(RemoveClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _clientStorage.GetOne(request.Id);
            client.Disable();

            await _clientStorage.Update(client);
            await _eventBus.Publish(client.PendingEvents.ToArray());

            return Unit.Value;
        }
    }
}
