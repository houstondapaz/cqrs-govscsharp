﻿using MediatR;
using System.Threading.Tasks;

namespace CQRSService.Domain.Queries
{
    public class QueryBus : IQueryBus
    {
        private readonly IMediator _mediator;

        public QueryBus(IMediator mediator)
            => _mediator = mediator;

        public Task<TResponse> Send<TQuery, TResponse>(TQuery query) where TQuery : IQuery<TResponse>
            => _mediator.Send(query);
    }
}
