package client

import (
	commands "github.com/houstondapaz/cqrs-govscsharp/golang/domain/commands"
	"github.com/google/uuid"
)

type RemoveClientCommand struct {
	commands.Commander
	clientId uuid.UUID
}

func NewRemoveClientCommand(clientId uuid.UUID) RemoveClientCommand {
	return RemoveClientCommand{
		clientId: clientId,
	}
}

func (c RemoveClientCommand) ClientId() uuid.UUID {
	return c.clientId
}

func (c RemoveClientCommand) Name() string {
	return "RemoveClientCommand"
}
