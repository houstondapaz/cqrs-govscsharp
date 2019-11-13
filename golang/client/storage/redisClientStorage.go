package client

import (
	"encoding/json"
	"fmt"
	"strings"
	"time"

	"github.com/go-redis/redis"
	"github.com/google/uuid"
	clientDomain "github.com/houstondapaz/cqrs-govscsharp/golang/client/domain"
)

const (
	baseKey = "CLIENTS"
)

type ClientStorage struct {
	clientDomain.ClientStorager
	redisClient *redis.Client
}

func NewClientStorage(redisClient *redis.Client) clientDomain.ClientStorager {
	return ClientStorage{
		redisClient: redisClient,
	}
}

func (cs ClientStorage) GetOne(id uuid.UUID) (*clientDomain.Client, error) {
	var client clientDomain.Client
	value, err := cs.redisClient.Get(fmt.Sprintf("%s:%s", baseKey, id.String())).Result()

	if err != nil {
		return nil, err
	}

	json.Unmarshal([]byte(value), &client)
	return &client, nil
}

func (cs ClientStorage) GetAll() ([]*clientDomain.Client, error) {
	keys, err := cs.redisClient.Keys(fmt.Sprintf("%s:*", baseKey)).Result()
	if err != nil {
		return nil, err
	}

	clients := []*clientDomain.Client{}

	for _, key := range keys {
		id, err := uuid.Parse(strings.ReplaceAll(key, fmt.Sprintf("%s:", baseKey), ""))
		if err != nil {
			return nil, err
		}

		client, err := cs.GetOne(id)
		if err != nil {
			return nil, err
		}

		clients = append(clients, client)
	}

	return clients, nil
}

func (cs ClientStorage) Add(client *clientDomain.Client) error {
	b, err := json.Marshal(client)
	if err != nil {
		return err
	}

	_, err = cs.redisClient.Set(fmt.Sprintf("%s:%s", baseKey, client.Id().String()), b, time.Duration(time.Hour*50)).Result()
	if err != nil {
		return err
	}
	return nil
}

func (cs ClientStorage) Update(client *clientDomain.Client) error {
	return cs.Add(client)
}
