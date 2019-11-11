package service

import (
	"context"
	"fmt"
	"time"

	binary "github.com/houstondapaz/cqrs-govscsharp/golang/binary"
	clientDomain "github.com/houstondapaz/cqrs-govscsharp/golang/client/domain"
	domainCommands "github.com/houstondapaz/cqrs-govscsharp/golang/domain/commands"
	domainQueries "github.com/houstondapaz/cqrs-govscsharp/golang/domain/queries"
	"github.com/golang/protobuf/ptypes/empty"
	"github.com/google/uuid"
)

const (
	timestampFormat = time.StampNano
	streamingCount  = 10
)

type ClientServer struct {
	queryBuser   domainQueries.QueryBuser
	commandBuser domainCommands.CommandBuser
}

func NewClientServer(queryBuser domainQueries.QueryBuser, commandBuser domainCommands.CommandBuser) *ClientServer {
	return &ClientServer{
		queryBuser:   queryBuser,
		commandBuser: commandBuser,
	}
}

func (cs *ClientServer) GetUser(ctx context.Context, req *binary.GetUserRequest) (*binary.User, error) {
	id, err := uuid.Parse(req.GetId())
	if err != nil {
		return nil, fmt.Errorf("error on parse id to guid: %s", err)
	}

	getClientQuery := clientDomain.NewGetClientQuery(id)

	result, err := cs.queryBuser.Send(getClientQuery)
	if err != nil {
		return nil, fmt.Errorf("error on get client: %s", err)
	}

	client := result.(*clientDomain.Client)

	return &binary.User{
		Id:   client.Id().String(),
		Name: client.Name(),
	}, nil
}

func (cs *ClientServer) Add(ctx context.Context, req *binary.AddUserRequest) (*empty.Empty, error) {
	command := clientDomain.NewInsertClientCommand(req.GetName())

	err := cs.commandBuser.Send(command)
	if err != nil {
		return nil, fmt.Errorf("error on get client: %s", err)
	}

	return &empty.Empty{}, nil
}

func (cs *ClientServer) GetUsers(req *binary.GetUsersRequest, stream binary.UserService_GetUsersServer) error {
	clients, err := cs.queryBuser.Send(clientDomain.NewGetClientsQuery())

	if err != nil {
		return fmt.Errorf("error on get clients: %s", err)
	}

	for _, client := range clients.([]*clientDomain.Client) {
		stream.SendMsg(&binary.User{
			Id:   client.Id().String(),
			Name: client.Name(),
		})
	}
	stream.Context().Done()
	return nil
}
