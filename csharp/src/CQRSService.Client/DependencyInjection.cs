using CQRSService.Client.Commands;
using CQRSService.Client.CQRSService.Domain.Commands;
using CQRSService.Client.Domain.Events;
using CQRSService.Client.Domain.Queries;
using CQRSService.Client.Events;
using CQRSService.Client.Queries;
using CQRSService.Client.Storage;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace CQRSService.Client
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddClientServices(this IServiceCollection services)
        {
            services.AddScoped<IStorage<Client>, RedisStorage>();

            services.AddScoped<IRequestHandler<InsertClientCommand, Unit>, InsertClientCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveClientCommand, Unit>, RemoveClientCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateClientCommand, Unit>, UpdateClientCommandHandler>();

            services.AddScoped<IRequestHandler<GetClientQuery, Client>, GetClientQueryHandler>();
            services.AddScoped<IRequestHandler<GetClientsQuery, IEnumerable<Client>>, GetClientsQueryHandler>();

            services.AddScoped<INotificationHandler<ClientCreated>, QueueEvents>();
            services.AddScoped<INotificationHandler<ClientUpdated>, QueueEvents>();
            services.AddScoped<INotificationHandler<ClientRemoved>, QueueEvents>();

            return services;
        }
    }
}
