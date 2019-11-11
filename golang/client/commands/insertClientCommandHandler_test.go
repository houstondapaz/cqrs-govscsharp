package client

import (
	"testing"

	client "github.com/cqrs-govscsharp/golang/client/domain"
	events "github.com/cqrs-govscsharp/golang/domain/events"
	"github.com/google/uuid"
	"github.com/stretchr/testify/mock"
)

type ClientStoragerMock struct {
	mock.Mock
}
func (ClientStoragerMock) GetOne(uuid.UUID) (*client.Client, error) {
	return nil, nil
}
func (ClientStoragerMock) GetAll() ([]*client.Client, error) {
	return nil, nil
}
func (cs ClientStoragerMock) Add(c *client.Client) error {
	cs.Called(c)
	return nil
}
func (ClientStoragerMock) Update(*client.Client) error {
	return nil
}

type EventBuserMock struct {
	mock.Mock
}
func (eb *EventBuserMock) Publish(e ...events.Eventer) error {
	eb.Called(e[0])
	return nil
}
func (EventBuserMock) Attach(events.EventHadler) error {
	return nil
}

func Test_Handle_should_call_Storage_with_name(t *testing.T) {
	clientStoragerMock := &ClientStoragerMock{}

	clientStoragerMock.On("Add", mock.MatchedBy(func(c *client.Client) bool {
		return c.Name() == "teste"
	})).Return(nil).Once()

	eventBuserMock := &EventBuserMock{}
	eventBuserMock.On("Publish", mock.MatchedBy(func(events.Eventer) bool {
		return true
	})).Return(nil).Once()

	commandHandler := NewInsertClientCommandHandler(clientStoragerMock, eventBuserMock)
	command := client.NewInsertClientCommand("teste")

	err := commandHandler.Handle(command)
	if err != nil {
		t.Fail()
	}

	clientStoragerMock.AssertExpectations(t)
}

func Test_Handle_should_call_EventBus_with_ClientCreated_event(t *testing.T) {
	clientStoragerMock := &ClientStoragerMock{}
	clientStoragerMock.On("Add", mock.MatchedBy(func(c *client.Client) bool {
		return c.Name() == "teste"
	})).Return(nil).Once()

	eventBuserMock := &EventBuserMock{}

	eventBuserMock.On("Publish", mock.MatchedBy(func(e events.Eventer) bool {
		return e.Name() == "ClientCreated"
	})).Return(nil).Once()

	commandHandler := NewInsertClientCommandHandler(clientStoragerMock, eventBuserMock)
	command := client.NewInsertClientCommand("teste")

	err := commandHandler.Handle(command)
	if err != nil {
		t.Fail()
	}

	eventBuserMock.AssertExpectations(t)
}
