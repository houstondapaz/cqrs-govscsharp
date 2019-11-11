package events

type EventBuser interface {
	Publish(events ...Eventer) error
	Attach(EventHadler) error
}
