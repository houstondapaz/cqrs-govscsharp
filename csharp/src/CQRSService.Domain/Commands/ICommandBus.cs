using System.Threading.Tasks;

namespace CQRSService.Domain.Commands
{
    public interface ICommandBus
    {
        Task Send<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
