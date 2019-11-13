using CQRSService.Client.CQRSService.Domain.Commands;
using CQRSService.Client.Domain.Queries;
using CQRSService.Domain.Commands;
using CQRSService.Domain.Queries;
using CQRSService.Protos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRSService.Service
{
    public class ClientService : UserService.UserServiceBase
    {
        private readonly IQueryBus _queryBus;
        private readonly ICommandBus _commandBus;

        public ClientService(IQueryBus queryBus, ICommandBus commandBus)
        {
            _queryBus = queryBus;
            _commandBus = commandBus;
        }
        public override async Task<User> GetUser(GetUserRequest request, ServerCallContext context)
        {
            try
            {
                var client = await _queryBus.Send<GetClientQuery, Client.Client>(new GetClientQuery(Guid.Parse(request.Id)));

                if (client == default)
                {
                    throw new RpcException(new Status(StatusCode.NotFound, "Client not found"));
                }

                return new User
                {
                    Id = client.Id.ToString(),
                    Name = client.Name
                };
            }
            catch (RpcException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }
        }

        public override async Task GetUsers(GetUsersRequest request, IServerStreamWriter<User> responseStream, ServerCallContext context)
        {
            try
            {
                var clients = await _queryBus.Send<GetClientsQuery, IEnumerable<Client.Client>>(new GetClientsQuery());
                foreach (var client in clients)
                {
                    await responseStream.WriteAsync(new User
                    {
                        Id = client.Id.ToString(),
                        Name = client.Name ?? ""
                    });
                }
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, ex.Message), ex.Message);
            }
        }

        public override async Task<Empty> Add(AddUserRequest request, ServerCallContext context)
        {
            try
            {
                await _commandBus.Send(new InsertClientCommand(request.Name));
                return new Empty();
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, ex.Message), ex.Message);
            }
        }
    }
}
