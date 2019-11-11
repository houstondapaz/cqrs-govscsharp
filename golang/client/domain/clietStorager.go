package client

import (
	"github.com/google/uuid"
)

type ClientStorager interface {
	GetOne(uuid.UUID) (*Client, error)
	GetAll() ([]*Client, error)
	Add(*Client) error
	Update(*Client) error
}
