using CQRSService.Client.CQRSService.Domain.Commands;
using CQRSService.Client.Storage;
using CQRSService.Domain.Commands;
using CQRSService.Domain.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSService.Client.Commands
{
    public class UpdateClientCommandHandler : ICommandHandler<UpdateClientCommand>
    {
        private readonly IStorage<Client> _clientStorage;
        private readonly IEventBus _eventBus;

        public UpdateClientCommandHandler(IStorage<Client> storageClient, IEventBus eventBus)
        {
            _clientStorage = storageClient;
            _eventBus = eventBus;
        }

        public async Task<Unit> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _clientStorage.GetOne(request.Id);
            client.SetName(request.Name);

            await _clientStorage.Update(client);
            await _eventBus.Publish(client.PendingEvents.ToArray());

            return Unit.Value;
        }
    }
}
