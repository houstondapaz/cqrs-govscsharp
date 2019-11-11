package domain

import (
	"github.com/google/uuid"
)

type Storager interface {
	GetOne(uuid.UUID) (Entitier, error)
	GetAll() ([]Entitier, error)
	Add(*Entitier) error
	Update(*Entitier) error
}
