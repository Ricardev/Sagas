using MediatR;

namespace Application.Payment;

public class PaymentApplication : IPaymentApplication
{
    private readonly IMediator _mediator;

    public PaymentApplication(IMediator mediator)
    {
        _mediator = mediator;
    }
}