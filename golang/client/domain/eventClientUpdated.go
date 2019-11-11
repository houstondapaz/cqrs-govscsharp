package client

import (
	events "github.com/houstondapaz/cqrs-govscsharp/golang/domain/events"
)

type ClientUpdated struct {
	events.Event
	before *Client
	after  *Client
}

func NewClientUpdated(before, after Client) *ClientUpdated {
	return &ClientUpdated{
		Event:  events.NewEvent("ClientUpdated"),
		after:  &after,
		before: &before,
	}
}
