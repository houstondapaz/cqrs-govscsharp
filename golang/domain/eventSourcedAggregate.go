package domain

import (
	events "github.com/houstondapaz/cqrs-govscsharp/golang/domain/events"
	"github.com/google/uuid"
)

type EventSourcedAggregate struct {
	EventSourcedAggregator
	id            uuid.UUID        `json:Id`
	isEnabled     bool             `json:IsEnabled`
	pendingEvents []events.Eventer `json:-`
}

func NewEventSourcedAggregate() EventSourcedAggregate {
	id, _ := uuid.NewUUID()
	return EventSourcedAggregate{
		isEnabled: true,
		id:        id,
	}
}

//Id getter
func (ea *EventSourcedAggregate) Id() uuid.UUID {
	return ea.id
}

func (ea *EventSourcedAggregate) SetId(id uuid.UUID) {
	ea.id = id
}

//IsEnabled getter
func (ea *EventSourcedAggregate) IsEnabled() bool {
	return ea.isEnabled
}

//IsEnabled getter
func (ea *EventSourcedAggregate) SetIsEnabled(isEnabled bool) {
	ea.isEnabled = isEnabled
}

//PendingEvents getter
func (ea *EventSourcedAggregate) PendingEvents() []events.Eventer {
	return ea.pendingEvents
}

//Append a new event
func (ea *EventSourcedAggregate) Append(event events.Eventer) {
	ea.pendingEvents = append(ea.pendingEvents, event)
}
