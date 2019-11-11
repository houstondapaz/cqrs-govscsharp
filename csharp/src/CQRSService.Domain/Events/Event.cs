using System;

namespace CQRSService.Domain.Events
{
    public class Event : IEvent
    {
        public Guid Id { get; } = Guid.NewGuid();
        public DateTime Timestamp { get; } = DateTime.UtcNow;
    }
}
