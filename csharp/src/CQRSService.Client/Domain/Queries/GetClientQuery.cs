using CQRSService.Domain.Queries;
using System;

namespace CQRSService.Client.Domain.Queries
{
    public class GetClientQuery : IQuery<Client>
    {
        public Guid Id { get; }

        public GetClientQuery(Guid id) => Id = id;
    }
}
