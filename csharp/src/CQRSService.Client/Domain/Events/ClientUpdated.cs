using CQRSService.Domain.Events;

namespace CQRSService.Client.Domain.Events
{
    public class ClientUpdated : Event
    {
        public Client Before { get; }
        public Client After { get; }
        public ClientUpdated(Client before, Client after)
        {
            Before = before;
            After = after;
        }
    }
}
