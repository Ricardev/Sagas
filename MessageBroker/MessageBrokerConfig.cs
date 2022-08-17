using RabbitMQ.Client;

namespace MessageBroker;

public static class MessageBrokerConfig
{
    public static IModel ChannelConfig()
    {
        var factory = new ConnectionFactory() { HostName = "localhost", Port = 5672};
        var _connection = factory.CreateConnection();
        var _channel = _connection.CreateModel();
        _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);
        return _channel;
    } 
}