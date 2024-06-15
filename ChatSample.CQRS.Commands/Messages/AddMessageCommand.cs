using MediatR;

namespace ChatSample.CQRS.Commands.Messages
{
    public class AddMessageCommand(Guid sender, Guid reciever, string messages) : IRequest<Model.Write.Messages>
    {
        public Guid Sender = sender;
        public Guid Receiver = reciever;
        public string Message = messages;
    }
}
