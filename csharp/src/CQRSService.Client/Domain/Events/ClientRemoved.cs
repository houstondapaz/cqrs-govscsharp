using CQRSService.Domain.Events;

namespace CQRSService.Client.Domain.Events
{
    public class ClientRemoved : Event
    {
        public Client Client { get; }
        public ClientRemoved(Client client) => Client = client;
    }
}
