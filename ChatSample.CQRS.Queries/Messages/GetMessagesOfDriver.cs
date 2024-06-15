using ChatSample.CQRS.Model.Read;
using MediatR;

namespace ChatSample.CQRS.Queries.Messages
{
    public class GetMessagesOfDriver(Guid Sender, Guid Receiver) : IRequest<List<MessagesReadModel>>
    {
        public Guid Sender = Sender;
        public Guid Receiver = Receiver;
    }
}
