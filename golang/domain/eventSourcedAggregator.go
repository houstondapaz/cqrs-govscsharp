package domain

import (
	events "github.com/cqrs-govscsharp/golang/domain/events"
)

type EventSourcedAggregator interface {
	Entitier
	PendingEvents() []events.Eventer
}
