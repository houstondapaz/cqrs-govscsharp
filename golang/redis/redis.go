package redis

import (
	"time"

	config "github.com/cqrs-govscsharp/golang/config"
	"github.com/go-redis/redis"
)

func NewRedisClient(config *config.Config) (*redis.Client, error) {
	redisClient := redis.NewClient(&redis.Options{
		Addr:        config.RedisHost(),
		Password:    config.RedisPass(),
		DB:          config.RedisDB(),
		MaxRetries:  2,
		IdleTimeout: 5 * time.Minute,
	})

	_, err := redisClient.Ping().Result()
	if err != nil {
		return nil, err
	}
	return redisClient, nil
}
