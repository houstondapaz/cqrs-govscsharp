package config

import (
	"os"
	"strconv"

	"github.com/joho/godotenv"
)

type Config struct {
	redisHost string
	redisPass string
	redisDB   int

	grpcPort string
}

func (c *Config) RedisHost() string {
	return c.redisHost
}

func (c *Config) RedisPass() string {
	return c.redisPass
}

func (c *Config) RedisDB() int {
	return c.redisDB
}

func (c *Config) GRPCPort() string {
	return c.grpcPort
}

func NewConfig() *Config {
	godotenv.Load()

	config := &Config{}
	config.redisHost = os.Getenv("REDIS_HOST")
	config.redisPass = os.Getenv("REDIS_PASS")

	if db, err := strconv.Atoi(os.Getenv("REDIS_DB")); err == nil {
		config.redisDB = db
	} else {
		config.redisDB = 0
	}

	if grpcPort, ok := os.LookupEnv("GRPC_PORT"); ok {
		config.grpcPort = grpcPort
	} else {
		config.grpcPort = ":5002"
	}

	return config
}
