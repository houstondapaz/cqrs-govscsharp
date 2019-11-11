using MediatR;

namespace CQRSService.Domain.Commands
{
    public interface ICommandHandler<in T> : IRequestHandler<T>
        where T : ICommand
    {
    }
}
