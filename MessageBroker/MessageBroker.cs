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
    public void PublishMessage<T>(T command, string exchange)
    {
        var message = JsonSerializer.Serialize(command);
        var body = Encoding.UTF8.GetBytes(message);
        _channel.BasicPublish(exchange: exchange,
                routingKey: "",
                basicProperties: null,
                body: body);
    }

    public void ReceiveMessage<T>(string eventQueue, Action<T> appServiceCall)
    {
        var consumer = new EventingBasicConsumer(_channel);
            Console.WriteLine(eventQueue);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                T? commandEvent = JsonSerializer.Deserialize<T>(message);
                if (commandEvent != null)
                    appServiceCall(commandEvent);
            };
            _channel.BasicConsume(queue: eventQueue,
                autoAck: false,
                consumer: consumer);
    }
}