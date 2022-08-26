using RabbitMQ.Client;

namespace MessageBroker;

public static class MessageBrokerConfig
{
    public static IModel ChannelConfig()
    {
        var channel = new ConnectionFactory { Uri = new Uri("amqp://admin:password@messageBroker:5672") }
            .CreateConnection()
            .CreateModel();
        return channel;
    } 
}