using MessageBroker;
using MessageBroker.EventModels;
using Microsoft.Extensions.Hosting;

namespace Application.Payment.Event;

public class PaymentEventListener : BackgroundService
{

    private readonly IMessageBroker _messageBroker;
    private readonly IPaymentApplication _paymentApplication;

    public PaymentEventListener(IMessageBroker messageBroker, IPaymentApplication application)
    {
        _messageBroker = messageBroker;
        _paymentApplication = application;
    }
    
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        ListenToCreatePaymentEvent();
        return Task.CompletedTask;
    }
    
    private void ListenToCreatePaymentEvent()
    {
         _messageBroker.ReceiveMessage<CreatePaymentEventModel>(EventQueue.CreatePaymentQueue, _paymentApplication.CreatePayment);
    }


}