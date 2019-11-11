using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CQRSService.Domain.Events
{
    public interface IEventBus
    {
        Task Publish<TEvent>(params TEvent[] events) where TEvent : IEvent;
    }
}
