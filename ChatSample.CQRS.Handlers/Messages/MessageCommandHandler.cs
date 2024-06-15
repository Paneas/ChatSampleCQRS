using MediatR;
using ChatSample.CQRS.Commands.Messages;
using ChatSample.CQRS.Database;
using ChatSample.CQRS.Events.Events;

namespace ChatSample.CQRS.Handlers.Messages
{
    public class MessageCommandHandler(WriteDBContext context, IMediator mediator) :
        IRequestHandler<AddMessageCommand, Model.Write.Messages>
    {
        private readonly WriteDBContext writeDBContext = context;
        private readonly IMediator _mediator = mediator;

        public async Task<Model.Write.Messages> Handle(AddMessageCommand request,
            CancellationToken cancellationToken)
        {
            var message = new Model.Write.Messages()
            {
                Message = request.Message,
                Receiver = request.Receiver,
                Sender = request.Sender,
                SentAtUtc = DateTime.UtcNow
            };

            writeDBContext.Messages.Add(message);

            await writeDBContext.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new MessageSentEvent
            {
                Reciever = request.Receiver,
                Sender = request.Sender,
                MessagePreview = request.Message[..20]
            });

            return message;
        }
    }
}
