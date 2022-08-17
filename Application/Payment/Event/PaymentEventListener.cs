using MessageBroker;
using Microsoft.Extensions.Hosting;

namespace Application.Payment.Event;

public class PaymentEventListener : BackgroundService
{

    private readonly IMessageBroker _messageBroker;

    public PaymentEventListener(IMessageBroker messageBroker)
    {
        _messageBroker = messageBroker;
    }
    
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
       _messageBroker.ReceiveMessage<>();
    }
}