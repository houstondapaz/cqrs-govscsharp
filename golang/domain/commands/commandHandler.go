package domain

type CommandHandler interface {
	CommandName() string
	Handle(Commander) error
}
