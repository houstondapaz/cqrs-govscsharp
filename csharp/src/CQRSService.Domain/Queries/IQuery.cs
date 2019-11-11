using MediatR;

namespace CQRSService.Domain.Queries
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
