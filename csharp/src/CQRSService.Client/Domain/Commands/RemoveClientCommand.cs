using CQRSService.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRSService.Client.CQRSService.Domain.Commands
{
    public class RemoveClientCommand : ICommand
    {
        public RemoveClientCommand(Guid id) => Id = id;

        public Guid Id { get; }
    }
}
