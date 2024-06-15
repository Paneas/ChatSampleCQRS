using ChatSample.CQRS.Events.Events;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace ChatSample.CQRS.Events.Repos
{
    public class RabbitMQRepo : IEventRepo
    {

        public Task Publish(IEvent message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            if (message is not MessageSentEvent)
                throw new Exception("Event not supported");

            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "msg_notifications",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

            var json = JsonSerializer.Serialize(message);

            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: string.Empty,
                     routingKey: "msg_notifications",
                     basicProperties: null,
                     body: body);

            return Task.CompletedTask;
        }
    }
}
