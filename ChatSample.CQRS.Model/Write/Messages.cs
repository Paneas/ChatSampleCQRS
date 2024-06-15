namespace ChatSample.CQRS.Model.Write
{
    public class Messages
    {
        public Guid Id;
        public Guid Sender { get; set; }
        public Guid Receiver { get; set; }
        public string Message { get; set; }
        public DateTime SentAtUtc { get; set; }
        public bool IsSeen { get; set; }

    }
}
