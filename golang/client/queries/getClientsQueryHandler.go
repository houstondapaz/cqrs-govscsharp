package client

import (
	client "github.com/houstondapaz/cqrs-govscsharp/golang/client/domain"
	queries "github.com/houstondapaz/cqrs-govscsharp/golang/domain/queries"
)

type GetClientsQueryHandler struct {
	queries.QueryHandler
	storage client.ClientStorager
}

func NewGetClientsQueryHandler(storage client.ClientStorager) GetClientsQueryHandler {
	return GetClientsQueryHandler{
		storage: storage,
	}
}
func (qh GetClientsQueryHandler) QueryName() string {
	return "GetClientsQuery"
}

func (qh GetClientsQueryHandler) Handle(query queries.Querier) (interface{}, error) {
	return qh.storage.GetAll()
}
