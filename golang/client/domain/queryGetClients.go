package client

import (
	queries "github.com/houstondapaz/cqrs-govscsharp/golang/domain/queries"
)

type GetClientsQuery struct {
	queries.Querier
	name string
}

func NewGetClientsQuery() *GetClientsQuery {
	return &GetClientsQuery{}
}

func (c *GetClientsQuery) Name() string {
	return "GetClientsQuery"
}
