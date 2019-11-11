using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CQRSService.Domain.Events
{
    public abstract class EventSourcedAggregate : IEventSourcedAggregate
    {
        [JsonProperty]
        public Guid Id { get; protected set; } = Guid.NewGuid();

        [JsonProperty]
        public bool IsEnabled { get; protected set; } = true;

        [JsonIgnore]
        public Queue<IEvent> PendingEvents { get; } = new Queue<IEvent>();

        protected void Append(IEvent @event) => PendingEvents.Enqueue(@event);
    }
}
