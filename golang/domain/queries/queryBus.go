package domain

import (
	"fmt"
	"sync"
)

//QueryBys is a implementation of QueryBuser
type QueryBus struct {
	QueryBuser
	mutex         sync.Mutex
	queryHandlers map[string]QueryHandler
}

//NewQueryBus create a new query bus
func NewQueryBus() QueryBuser {
	return QueryBus{
		queryHandlers: make(map[string]QueryHandler),
	}
}

//Attach includes an handle
func (qb QueryBus) Attach(handler QueryHandler) error {
	qb.mutex.Lock()
	defer qb.mutex.Unlock()

	if qb.queryHandlers[handler.QueryName()] != nil {
		return fmt.Errorf("query %s already attached", handler.QueryName())
	}

	qb.queryHandlers[handler.QueryName()] = handler
	return nil
}

//Send execute a query on an attached handle
func (qb QueryBus) Send(query Querier) (interface{}, error) {
	if qb.queryHandlers[query.Name()] == nil {
		return nil, fmt.Errorf("no handler attached to %s query", query.Name())
	}

	handlerPointer := qb.queryHandlers[query.Name()]
	return handlerPointer.Handle(query)
}
