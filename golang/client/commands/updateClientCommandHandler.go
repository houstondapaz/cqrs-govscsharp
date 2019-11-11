package client

import (
	"fmt"

	client "github.com/houstondapaz/cqrs-govscsharp/golang/client/domain"
	commands "github.com/houstondapaz/cqrs-govscsharp/golang/domain/commands"
	events "github.com/houstondapaz/cqrs-govscsharp/golang/domain/events"
)

type UpdateClientCommandHandler struct {
	commands.CommandHandler
	storage  client.ClientStorager
	eventBus events.EventBuser
}

func NewUpdateClientCommandHandler(clientStorager client.ClientStorager, eventBus events.EventBuser) UpdateClientCommandHandler {
	return UpdateClientCommandHandler{
		storage:  clientStorager,
		eventBus: eventBus,
	}
}

func (ch UpdateClientCommandHandler) CommandName() string {
	return "UpdateClientCommand"
}

func (ch UpdateClientCommandHandler) Handle(command commands.Commander) error {
	updateClientCommand := command.(client.UpdateClientCommand)
	c, err := ch.storage.GetOne(updateClientCommand.ClientId())
	if err != nil {
		return err
	}

	if c == nil {
		return fmt.Errorf("client id %s not found", updateClientCommand.ClientId())
	}

	c.SetName(updateClientCommand.ClientName())

	err = ch.storage.Update(c)

	if err != nil {
		return err
	}

	return ch.eventBus.Publish(c.PendingEvents()...)
}
