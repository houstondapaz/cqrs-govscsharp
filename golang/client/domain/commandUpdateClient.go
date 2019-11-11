package client

import (
	commands "github.com/cqrs-govscsharp/golang/domain/commands"
	"github.com/google/uuid"
)

type UpdateClientCommand struct {
	commands.Commander
	clientName string
	clientId   uuid.UUID
}

func NewUpdateClientCommand(clientId uuid.UUID, clientName string) UpdateClientCommand {
	return UpdateClientCommand{
		clientName: clientName,
		clientId:   clientId,
	}
}

func (c UpdateClientCommand) ClientName() string {
	return c.clientName
}

func (c UpdateClientCommand) ClientId() uuid.UUID {
	return c.clientId
}

func (c UpdateClientCommand) Name() string {
	return "UpdateClientCommand"
}
