using AutoMapper;
using Domain.Payment.Command;
using MediatR;
using MessageBroker;
using MessageBroker.EventModels;

namespace Application.Payment;

public class PaymentApplication : IPaymentApplication
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IMessageBroker _messageBroker;

    public PaymentApplication(IMediator mediator, IMapper mapper, IMessageBroker messageBroker)
    {
        _mediator = mediator;
        _mapper = mapper;
        _messageBroker = messageBroker;
    }

    public async void CreatePayment(CreatePaymentEventModel validateProductEvent)
    {
        var createPaymentCommand = _mapper.Map<CreatePaymentCommand>(validateProductEvent);
        var success = await _mediator.Send(createPaymentCommand);
        if (!success)
        {
            var rollbackOrderProduct = new RollbackProductEventModel(validateProductEvent.OrderId, validateProductEvent.ProductId);
            _messageBroker.PublishMessage(rollbackOrderProduct, EventQueue.RollbackProductQueue, "Product Exchange");
        }
    }
    
}