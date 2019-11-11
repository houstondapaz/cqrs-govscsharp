package domain

type CommandBuser interface {
	Send(Commander) error
	Attach(CommandHandler) error
}
