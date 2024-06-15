namespace ChatSample.CQRS.Model.Read
{
    public class MessagesReadModel
    {
        public Guid Id { get; set; }
        public Guid Sender { get; set; }
        public Guid Receiver { get; set; }

        public string Message { get; set; }

        public DateTime SentAtUtc { get; set; }
    }
}
