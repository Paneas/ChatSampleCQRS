using MediatR;
using ChatSample.CQRS.Events.Events;
using ChatSample.CQRS.Events.Repos;

namespace ChatSample.CQRS.Events.Handlers
{
    public class MessageEventHandler(IEventRepo eventRepo) : INotificationHandler<MessageSentEvent>
    {
        private readonly IEventRepo _eventRepo = eventRepo;

        public async Task Handle(MessageSentEvent notification, CancellationToken cancellationToken)
        {
            await _eventRepo.Publish(notification);
        }
    }
}
