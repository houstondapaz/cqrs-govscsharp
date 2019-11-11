package client

import (
	"fmt"

	eventDomain "github.com/cqrs-govscsharp/golang/domain/events"
)

type QueueEvents struct {
	eventDomain.EventHadler
}

func NewQueueEvents() QueueEvents {
	return QueueEvents{}
}

func (eh QueueEvents) Handle(event eventDomain.Eventer) error {
	fmt.Printf("QueueEvents %s", event.Name())
	return nil
}

func (eh QueueEvents) EventNames() []string {
	return []string{"ClientCreated", "ClientRemoved", "ClientUpdated"}
}
