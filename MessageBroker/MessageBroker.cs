using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MessageBroker;

public class MessageBroker : IMessageBroker
{
    private readonly IModel _channel;

    public MessageBroker(IModel channel)
    {
        _channel = channel;
    }
    public void PublishMessage<T>(T command, string eventQueue)
    {
        _channel.QueueDeclare(queue: eventQueue, durable:true, exclusive: false, autoDelete: false, arguments: null);
            var message = JsonSerializer.Serialize(command);
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange: "logs",
                routingKey: eventQueue,
                basicProperties: null,
                body: body);
            Console.WriteLine(" [x] Sent {0}", message);
    }

    public T? ReceiveMessage<T>(string eventQueue)
    {
        T? commandEvent = default(T);

        var consumer = new EventingBasicConsumer(_channel);
            
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                commandEvent = JsonSerializer.Deserialize<T>(message);
            };
            
            _channel.BasicConsume(queue: eventQueue,
                autoAck: true,
                consumer: consumer);

            return commandEvent;
    }
}