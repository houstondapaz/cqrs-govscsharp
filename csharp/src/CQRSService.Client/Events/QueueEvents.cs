using CQRSService.Client.Domain.Events;
using CQRSService.Domain.Events;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSService.Client.Events
{
    public class QueueEvents : 
        IEventHandler<ClientCreated>
        , IEventHandler<ClientRemoved>
        , IEventHandler<ClientUpdated>
    {
        public Task Handle(ClientCreated notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(ClientRemoved notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Handle(ClientUpdated notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
