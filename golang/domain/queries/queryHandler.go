package domain

type QueryHandler interface {
	QueryName() string
	Handle(Querier) (interface{}, error)
}
