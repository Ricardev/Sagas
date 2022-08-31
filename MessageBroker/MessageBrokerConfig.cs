using RabbitMQ.Client;

namespace MessageBroker;

public static class MessageBrokerConfig
{
    public static IModel ChannelConfig()
    {
        
        var channel = new ConnectionFactory() {HostName = "messageBroker", UserName = "admin", Password = "password", Port = 5672}.CreateConnection();
        
        return channel.CreateModel();
    } 
}