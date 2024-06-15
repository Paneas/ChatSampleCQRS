using ChatSample.CQRS.Events.Events;

namespace ChatSample.CQRS.Events.Repos
{
    public interface IEventRepo
    {
        Task Publish(IEvent message);
    }
}
