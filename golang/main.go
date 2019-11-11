package main

import (
	"fmt"
	"log"
	"net"
	"os"
	"os/signal"
	"syscall"

	binary "github.com/cqrs-govscsharp/golang/binary"
	"github.com/cqrs-govscsharp/golang/client"
	"github.com/cqrs-govscsharp/golang/config"
	commands "github.com/cqrs-govscsharp/golang/domain/commands"
	"github.com/cqrs-govscsharp/golang/domain/events"
	queries "github.com/cqrs-govscsharp/golang/domain/queries"
	"github.com/cqrs-govscsharp/golang/redis"
	"github.com/cqrs-govscsharp/golang/service"

	"go.uber.org/dig"
	"google.golang.org/grpc"
)

func BuildContainer() (*dig.Container, error) {
	container := dig.New()

	err := container.Provide(config.NewConfig)
	if err != nil {
		return nil, err
	}
	err = container.Provide(redis.NewRedisClient)
	if err != nil {
		return nil, err
	}
	err = container.Provide(queries.NewQueryBus)
	if err != nil {
		return nil, err
	}
	err = container.Provide(commands.NewCommandBus)
	if err != nil {
		return nil, err
	}
	err = container.Provide(events.NewEventBus)
	if err != nil {
		return nil, err
	}
	err = container.Provide(service.NewServer)
	if err != nil {
		return nil, err
	}
	err = container.Provide(service.NewClientServer)
	if err != nil {
		return nil, err
	}

	return container, nil
}

func main() {
	container, err := BuildContainer()
	if err != nil {
		panic(err)
	}

	err = client.ProvideServices(container)

	if err != nil {
		panic(err)
	}

	err = container.Invoke(func(config *config.Config, server *grpc.Server, clientServer *service.ClientServer) {
		lis, err := net.Listen("tcp", config.GRPCPort())
		if err != nil {
			log.Panicf("Error on open tcp port: %v", err)
		}
		defer lis.Close()

		binary.RegisterUserServiceServer(server, clientServer)
		if err := server.Serve(lis); err != nil {
			log.Panicf("Error on start grpc server: %v", err)
		}
		server.Stop()
	})

	if err != nil {
		panic(err)
	}

	c := make(chan os.Signal, 1)
	signal.Notify(c, os.Interrupt, syscall.SIGINT, syscall.SIGTERM)

	cause := <-c

	fmt.Printf("Shutting down now. Cause %s", cause)
}
