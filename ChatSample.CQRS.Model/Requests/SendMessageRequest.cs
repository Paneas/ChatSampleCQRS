namespace ChatSample.CQRS.Model.Requests
{
    public class SendMessageRequest
    {
        public Guid FromUser { get; set; }
        public Guid ToUser { get; set; }

        public string Body { get; set; }
    }
}
