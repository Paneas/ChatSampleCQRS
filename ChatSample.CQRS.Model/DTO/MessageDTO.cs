using ChatSample.CQRS.Model.Write;

namespace ChatSample.CQRS.Model.DTO
{
    public class MessageDTO
    {
        public Guid Id { get; set; }

        public Guid UserFrom { get; set; }
        public Guid UserTo { get; set; }
        public string Message { get; set; }

        public static MessageDTO ToDto(Messages messages) => new MessageDTO
        {
            Id = messages.Id,
            UserFrom = messages.Sender,
            UserTo = messages.Receiver,
            Message = messages.Message
        };
    }
}
