using CQRSService.Domain.Events;
namespace CQRSService.Client.Domain.Events
{
    public class ClientCreated : Event
    {
        public Client Client { get; }
        public ClientCreated(Client client) => Client = client;
    }
}
