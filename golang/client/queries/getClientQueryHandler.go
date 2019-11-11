package client

import (
	client "github.com/houstondapaz/cqrs-govscsharp/golang/client/domain"
	queries "github.com/houstondapaz/cqrs-govscsharp/golang/domain/queries"
)

type GetClientQueryHandler struct {
	queries.QueryHandler
	storage client.ClientStorager
}

func NewGetClientQueryHandler(storage client.ClientStorager) GetClientQueryHandler {
	return GetClientQueryHandler{
		storage: storage,
	}
}

func (qh GetClientQueryHandler) QueryName() string {
	return "GetClientQuery"
}

func (qh GetClientQueryHandler) Handle(query queries.Querier) (interface{}, error) {
	getClientQuery := query.(client.GetClientQuery)
	client, err := qh.storage.GetOne(getClientQuery.ClientId())

	if err != nil {
		return nil, err
	}

	return client, nil
}
