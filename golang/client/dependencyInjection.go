package client

import (
	commands "github.com/houstondapaz/cqrs-govscsharp/golang/client/commands"
	events "github.com/houstondapaz/cqrs-govscsharp/golang/client/events"
	queries "github.com/houstondapaz/cqrs-govscsharp/golang/client/queries"
	storage "github.com/houstondapaz/cqrs-govscsharp/golang/client/storage"
	commandDomain "github.com/houstondapaz/cqrs-govscsharp/golang/domain/commands"
	eventDomain "github.com/houstondapaz/cqrs-govscsharp/golang/domain/events"
	queryDomain "github.com/houstondapaz/cqrs-govscsharp/golang/domain/queries"
	"go.uber.org/dig"
)

func provideQueries(container *dig.Container) error {
	container.Provide(queries.NewGetClientQueryHandler)
	container.Provide(queries.NewGetClientsQueryHandler)

	return container.Invoke(func(
		queryBus queryDomain.QueryBuser,
		getClientQueryHandler queries.GetClientQueryHandler,
		getClientsQueryHandler queries.GetClientsQueryHandler,
	) {
		queryBus.Attach(getClientQueryHandler)
		queryBus.Attach(getClientsQueryHandler)
	})
}

func provideCommands(container *dig.Container) error {
	container.Provide(commands.NewInsertClientCommandHandler)
	container.Provide(commands.NewRemoveClientCommandHandler)
	container.Provide(commands.NewUpdateClientCommandHandler)

	return container.Invoke(func(
		commandBus commandDomain.CommandBuser,
		insertClientCommandHandler commands.InsertClientCommandHandler,
		updateClientCommandHandler commands.UpdateClientCommandHandler,
		removeClientCommandHandler commands.RemoveClientCommandHandler,
	) {
		commandBus.Attach(insertClientCommandHandler)
		commandBus.Attach(removeClientCommandHandler)
		commandBus.Attach(updateClientCommandHandler)
	})
}

func provideEvents(container *dig.Container) error {
	container.Provide(events.NewQueueEvents)

	return container.Invoke(func(
		eventBus eventDomain.EventBuser,
		queueEvents events.QueueEvents,
	) {
		eventBus.Attach(queueEvents)
	})
}

func ProvideServices(container *dig.Container) error {
	container.Provide(storage.NewClientStorage)

	err := provideQueries(container)

	if err != nil {
		return err
	}

	err = provideCommands(container)

	if err != nil {
		return err
	}

	err = provideEvents(container)

	if err != nil {
		return err
	}
	return nil
}
