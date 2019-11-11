package client

import (
	commands "github.com/houstondapaz/cqrs-govscsharp/golang/domain/commands"
)

type InsertClientCommand struct {
	commands.Commander
	clientName string
}

func NewInsertClientCommand(clientName string) InsertClientCommand {
	return InsertClientCommand{
		clientName: clientName,
	}
}

func (c InsertClientCommand) ClientName() string {
	return c.clientName
}

func (c InsertClientCommand) Name() string {
	return "InsertClientCommand"
}
