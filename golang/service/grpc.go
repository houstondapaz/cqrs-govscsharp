package service

import (
	"google.golang.org/grpc"
)

func NewServer() *grpc.Server {
	return grpc.NewServer()
	// wppProto.RegisterConsumerServiceServer(s, &Server{})
}
