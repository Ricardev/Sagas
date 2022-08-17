using MessageBroker;
using MessageBroker.EventModels;
using Microsoft.Extensions.Hosting;

namespace Application.Products.Event;

public class ProductEventListener : BackgroundService
{

    private readonly IMessageBroker _messageBroker;
    private readonly IProductApplication _productApplication;

    public ProductEventListener(IMessageBroker messageBroker, IProductApplication productApplication)
    {
        _messageBroker = messageBroker;
        _productApplication = productApplication;
    }
    
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        ListenToValidateProductEvent();
        ListenToRollbackProductEvent();
        return Task.CompletedTask;
    }

    private void ListenToValidateProductEvent()
    {
        var order = _messageBroker.ReceiveMessage<CreateOrderEventModel>(EventQueue.ValidateProductQueue);
        if(order != null) _productApplication.OrderProduct(order);
    }

    private void ListenToRollbackProductEvent()
    {
        var payment = _messageBroker.ReceiveMessage<PaymentEventModel>(EventQueue.RollbackProductQueue);
        if(payment != null) _productApplication.RollbackOrderProduct();
    }
}