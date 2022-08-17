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
        ListenToRollbackPaymentEvent();
        return Task.CompletedTask;
    }
    
    private void ListenToCreatePaymentEvent()
    {
        var productEvent = _messageBroker.ReceiveMessage<ValidateProductEventModel>(EventQueue.CreatePaymentQueue);
        if(productEvent != null) _paymentApplication.CreatePayment(productEvent);
    }

    private void ListenToRollbackPaymentEvent()
    {
        var payment = _messageBroker.ReceiveMessage<PaymentEventModel>(EventQueue.RollbackPaymentQueue);
        if(payment != null) _paymentApplication.RollbackCreatePayment();
    }
}