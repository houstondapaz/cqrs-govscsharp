package client

import (
	events "github.com/houstondapaz/cqrs-govscsharp/golang/domain/events"
)

type ClientRemoved struct {
	events.Event
	client *Client
}

func NewClientRemoved(client Client) *ClientRemoved {
	return &ClientRemoved{
		Event:  events.NewEvent("ClientRemoved"),
		client: &client,
	}
}
