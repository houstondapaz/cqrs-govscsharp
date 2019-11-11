package client

import (
	client "github.com/houstondapaz/cqrs-govscsharp/golang/client/domain"
	commands "github.com/houstondapaz/cqrs-govscsharp/golang/domain/commands"
	events "github.com/houstondapaz/cqrs-govscsharp/golang/domain/events"
)

type RemoveClientCommandHandler struct {
	commands.CommandHandler
	storage  client.ClientStorager
	eventBus events.EventBuser
}

func NewRemoveClientCommandHandler(clientStorager client.ClientStorager, eventBus events.EventBuser) RemoveClientCommandHandler {
	return RemoveClientCommandHandler{
		storage:  clientStorager,
		eventBus: eventBus,
	}
}

func (ch RemoveClientCommandHandler) CommandName() string {
	return "RemoveClientCommand"
}

func (ch RemoveClientCommandHandler) Handle(command commands.Commander) error {
	c, err := ch.storage.GetOne(command.(client.RemoveClientCommand).ClientId())
	if err != nil {
		return err
	}

	c.Disable()

	err = ch.storage.Update(c)

	if err != nil {
		return err
	}

	return ch.eventBus.Publish(c.PendingEvents()...)
}
