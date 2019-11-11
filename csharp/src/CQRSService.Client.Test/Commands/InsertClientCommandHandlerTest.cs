using CQRSService.Client.Commands;
using CQRSService.Client.Domain.Events;
using CQRSService.Client.Storage;
using CQRSService.Domain.Events;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSService.Client.Test.Commands
{
    [TestFixture]
    public class InsertClientCommandHandlerTest
    {
        private readonly Mock<IStorage<Client>> _storageMock;
        private readonly Mock<IEventBus> _eventBusMock;

        public InsertClientCommandHandlerTest()
        {
            _storageMock = new Mock<IStorage<Client>>();
            _eventBusMock = new Mock<IEventBus>();
        }
        [Test]
        public async Task OnHandle_should_callStorage_with_name()
        {
            _storageMock.Invocations.Clear();

            var clientName = "teste_client";
            var handler = new InsertClientCommandHandler(_storageMock.Object, _eventBusMock.Object);
            await handler.Handle(new CQRSService.Domain.Commands.InsertClientCommand(clientName), CancellationToken.None);

            _storageMock.Verify(a => a.Add(It.Is<Client>(c => c.Name == clientName)), Times.Once);
        }

        [Test]
        public async Task OnHandle_should_callEventBus_()
        {
            _eventBusMock.Invocations.Clear();

            var clientName = "teste_client";
            var handler = new InsertClientCommandHandler(_storageMock.Object, _eventBusMock.Object);
            await handler.Handle(new CQRSService.Domain.Commands.InsertClientCommand(clientName), CancellationToken.None);

            _eventBusMock.Verify(a => a.Publish(It.Is<IEvent[]>(c => c.Length == 1 && c[0].GetType() == typeof(ClientCreated))), Times.Once);
        }
    }
}
