using MediatR;

namespace ChatSample.CQRS.Events.Events
{
    public class MessageSentEvent : INotification, IEvent
    {
        public Guid Sender { get; set; }
        public Guid Reciever { get; set; }
        public string MessagePreview { get; set; }
    }
}
