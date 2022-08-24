namespace MessageBroker;

public interface IMessageBroker
{
    public void PublishMessage<T>(T command, string eventQueue, string exchange);
    public void ReceiveMessage<T>(string eventQueue, Action<T> appServiceCall);
}