package domain

type QueryBuser interface {
	Send(Querier) (interface{}, error)
	Attach(QueryHandler) error
}
