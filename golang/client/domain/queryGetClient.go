package client

import (
	queries "github.com/cqrs-govscsharp/golang/domain/queries"
	"github.com/google/uuid"
)

type GetClientQuery struct {
	queries.Querier
	clientId uuid.UUID
}

func NewGetClientQuery(clientId uuid.UUID) GetClientQuery {
	return GetClientQuery{
		clientId: clientId,
	}
}

func (c GetClientQuery) Name() string {
	return "GetClientQuery"
}

func (c GetClientQuery) ClientId() uuid.UUID {
	return c.clientId
}
