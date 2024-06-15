using MediatR;
using Microsoft.EntityFrameworkCore;
using ChatSample.CQRS.Database;
using ChatSample.CQRS.Model.Read;
using ChatSample.CQRS.Queries.Messages;

namespace ChatSample.CQRS.Handlers.Messages
{
    public class MessageQueryHandler(ReadDBContext dbread) :
        IRequestHandler<GetMessagesOfDriver, List<MessagesReadModel>>
    {
        private readonly ReadDBContext _readDBContext = dbread;

        public async Task<List<MessagesReadModel>> Handle(GetMessagesOfDriver request, CancellationToken cancellationToken)
        {
            var msgs = await _readDBContext.Messages
                            .Where(m => (m.Sender == request.Sender && m.Receiver == request.Receiver)
                                            || m.Sender == request.Receiver && m.Receiver == request.Sender)
                            .OrderBy(m => m.SentAtUtc)
                            .Take(10)
                            .ToListAsync(cancellationToken);

            return msgs;
        }
    }
}
