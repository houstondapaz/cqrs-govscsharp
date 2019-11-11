using CQRSService.Client.Domain.Queries;
using CQRSService.Client.Queries;
using CQRSService.Client.Storage;
using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSService.Client.Test.Queries
{
    [TestFixture]
    public class GetClientQueryHandlerTest
    {
        private readonly Mock<IStorage<Client>> _clientStorageMoq;
        private readonly Client _client;

        public GetClientQueryHandlerTest()
        {
            _clientStorageMoq = new Mock<IStorage<Client>>();
            _client = new Client("teste");
            _clientStorageMoq.Setup(c => c.GetOne(It.IsAny<Guid>())).ReturnsAsync(_client);
        }

        [Test]
        public async Task Handle_returnSpecifiedId()
        {
            var queryHandler = new GetClientQueryHandler(_clientStorageMoq.Object);

            var client = await queryHandler.Handle(new GetClientQuery(_client.Id), CancellationToken.None);
            Assert.AreEqual(_client.Id, client.Id);
        }
    }
}
