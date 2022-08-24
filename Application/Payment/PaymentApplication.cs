using AutoMapper;
using Domain.Payment.Command;
using MediatR;
using MessageBroker.EventModels;

namespace Application.Payment;

public class PaymentApplication : IPaymentApplication
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public PaymentApplication(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public void CreatePayment(CreatePaymentEventModel validateProductEvent)
    {
        var createPaymentCommand = _mapper.Map<CreatePaymentCommand>(validateProductEvent);
        _mediator.Publish(createPaymentCommand);
    }

    public void RollbackCreatePayment(RollbackPaymentEventModel paymentEvent)
    {
        throw new NotImplementedException();
    }
}