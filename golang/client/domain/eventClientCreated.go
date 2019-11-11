package client

import (
	events "github.com/cqrs-govscsharp/golang/domain/events"
)

type ClientCreated struct {
	events.Event
	client *Client
}

func NewClientCreated(client Client) *ClientCreated {
	return &ClientCreated{
		client: &client,
		Event:  events.NewEvent("ClientCreated"),
	}
}
