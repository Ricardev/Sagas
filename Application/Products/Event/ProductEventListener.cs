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
        _messageBroker.ReceiveMessage<ReserveProductEventModel>(EventQueue.ValidateProductQueue, _productApplication.OrderProduct);
    }

    private void ListenToRollbackProductEvent()
    {
         _messageBroker.ReceiveMessage<RollbackProductEventModel>(EventQueue.RollbackProductQueue, _productApplication.RollbackOrderProduct);
    }
}