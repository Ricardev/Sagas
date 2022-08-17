namespace MessageBroker;

public interface IMessageBroker
{
    public void PublishMessage<T>(T command, string eventQueue);
    public T? ReceiveMessage<T>(string eventQueue);
}