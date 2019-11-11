package domain

import (
	events "github.com/houstondapaz/cqrs-govscsharp/golang/domain/events"
)

type EventSourcedAggregator interface {
	Entitier
	PendingEvents() []events.Eventer
}
