using RabbitMQ.Client;

namespace MessageBroker;

public static class MessageBrokerConfig
{
    public static IModel ChannelConfig()
    {
        var channel = new ConnectionFactory { Uri = new Uri("amqp://guest:guest@localhost:5672") }
            .CreateConnection()
            .CreateModel();
        return channel;
    } 
}