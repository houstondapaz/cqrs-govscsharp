package domain

import (
	"github.com/google/uuid"
)

type Entitier interface {
	Id() uuid.UUID
}
