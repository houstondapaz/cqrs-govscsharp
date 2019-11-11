using MediatR;
using System;

namespace CQRSService.Domain.Events
{
    public interface IEvent : INotification
    {
        Guid Id { get; }
        DateTime Timestamp { get; }
    }
}
