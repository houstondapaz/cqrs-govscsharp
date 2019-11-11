package client

import (
	client "github.com/cqrs-govscsharp/golang/client/domain"
	commands "github.com/cqrs-govscsharp/golang/domain/commands"
	events "github.com/cqrs-govscsharp/golang/domain/events"
)

type InsertClientCommandHandler struct {
	commands.CommandHandler
	storage  client.ClientStorager
	eventBus events.EventBuser
}

func NewInsertClientCommandHandler(storage client.ClientStorager, eventBus events.EventBuser) InsertClientCommandHandler {
	return InsertClientCommandHandler{
		storage:  storage,
		eventBus: eventBus,
	}
}

func (ch InsertClientCommandHandler) CommandName() string {
	return "InsertClientCommand"
}

func (ch InsertClientCommandHandler) Handle(command commands.Commander) error {
	c := client.NewClient(command.(client.InsertClientCommand).ClientName())
	err := ch.storage.Add(c)

	if err != nil {
		return err
	}

	return ch.eventBus.Publish(c.PendingEvents()...)
}
