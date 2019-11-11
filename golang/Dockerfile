FROM golang:1.12.4 as builder

WORKDIR $GOPATH/src/github.com/houstondapaz/cqrs-govscsharp/golang/
COPY . .

RUN go get -d -v ./...

RUN CGO_ENABLED=0 GOOS=linux go build -a -installsuffix cgo -o /go/bin/CQRSService

FROM alpine:latest  

RUN apk --no-cache add ca-certificates

WORKDIR /root/

# Copy the Pre-built binary file from the previous stage
COPY --from=builder /go/bin/CQRSService .

EXPOSE 5002

CMD ["./CQRSService"] 