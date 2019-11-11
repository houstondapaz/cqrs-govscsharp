using CQRSService.Client.Domain.Queries;
using CQRSService.Client.Queries;
using CQRSService.Client.Storage;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSService.Client.Test.Queries
{
    [TestFixture]
    public class GetClientsQueryHandlerTest
    {
        private readonly Mock<IStorage<Client>> _clientStorageMoq;
        private readonly Client _client;

        public GetClientsQueryHandlerTest()
        {
            _clientStorageMoq = new Mock<IStorage<Client>>();
            _client = new Client("teste");
            _clientStorageMoq.Setup(c => c.GetAll()).ReturnsAsync(new List<Client> { _client });
        }

        [Test]
        public async Task Handle_returnAllClients()
        {
            var queryHandler = new GetClientsQueryHandler(_clientStorageMoq.Object);

            var clients = await queryHandler.Handle(new GetClientsQuery(), CancellationToken.None);
            Assert.AreEqual(1, clients.Count());
            Assert.AreEqual(_client.Id, clients.First().Id);
        }
    }
}
