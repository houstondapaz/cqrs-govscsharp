package client

import (
	"encoding/json"

	"github.com/google/uuid"

	"github.com/houstondapaz/cqrs-govscsharp/golang/domain"
)

type Client struct {
	domain.EventSourcedAggregate
	name string `json:"Name"`
}

func NewClient(name string) *Client {
	client := &Client{
		name:                  name,
		EventSourcedAggregate: domain.NewEventSourcedAggregate(),
	}

	client.Append(NewClientCreated(*client))

	return client
}

func (c *Client) MarshalJSON() ([]byte, error) {
	return json.Marshal(map[string]interface{}{
		"Id":        c.Id(),
		"Name":      c.Name(),
		"IsEnabled": c.IsEnabled(),
	})
}

type clientUnmarshal struct {
	Id        uuid.UUID
	Name      string
	IsEnabled bool
}

func (c *Client) UnmarshalJSON(b []byte) error {
	var cc *clientUnmarshal

	err := json.Unmarshal(b, &cc)
	if err != nil {
		return err
	}

c.name = cc.Name
c.SetIsEnabled(cc.IsEnabled)
c.SetId(cc.Id)

	return nil
}

func (c *Client) Name() string {
	return c.name
}

func (c *Client) SetName(name string) {
	before := *c
	c.name = name
	c.Append(NewClientUpdated(before, *c))
}

func (c *Client) Disable() {
	c.SetIsEnabled(false)
	c.Append(NewClientRemoved(*c))
}
