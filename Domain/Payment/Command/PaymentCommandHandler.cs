using Domain.Payment.Command;
using MediatR;

namespace Payment.Command;

public class PaymentCommandHandler : IRequestHandler<MakePaymentCommand>, 
                                        IRequestHandler<CreatePaymentCommand>, 
                                        IRequestHandler<CancelPaymentCommand>
{
    public Task<Unit> Handle(MakePaymentCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Unit> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Unit> Handle(CancelPaymentCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}