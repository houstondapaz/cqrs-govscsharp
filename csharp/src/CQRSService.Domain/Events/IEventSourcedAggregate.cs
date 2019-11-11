using System.Collections.Generic;

namespace CQRSService.Domain.Events
{
    public interface IEventSourcedAggregate : IEntity
    {
        Queue<IEvent> PendingEvents { get; }
    }
}
