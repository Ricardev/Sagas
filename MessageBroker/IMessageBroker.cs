namespace MessageBroker;

public interface IMessageBroker
{
    public void PublishMessage<T>(T command, string eventQueue, string exchange);
    public T? ReceiveMessage<T>(string eventQueue);
}