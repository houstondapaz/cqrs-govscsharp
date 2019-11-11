using CQRSService.Domain.Commands;

namespace CQRSService.Client.CQRSService.Domain.Commands
{
    public class InsertClientCommand : ICommand
    {
        public InsertClientCommand(string name) => Name = name;

        public string Name { get; }
    }
}
