using CQRSService.Domain.Commands;
using System;

namespace CQRSService.Client.CQRSService.Domain.Commands
{
    public class UpdateClientCommand : ICommand
    {
        public Guid Id { get; }
        public string Name { get; }

        public UpdateClientCommand(Guid id, string name)
        {
            Name = name;
            Id = id;
        }
    }
}
