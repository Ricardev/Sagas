using Domain.Payment.Builders;
using MediatR;

namespace Domain.Payment.Command;

public class PaymentCommandHandler : IRequestHandler<CreatePaymentCommand, bool>
{
    private readonly IPaymentRepository _repository;

    public PaymentCommandHandler(  IPaymentRepository repository)
    {
        _repository = repository;
    }
    
    public Task<bool> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var payment = new PaymentBuilder()
                .SetPaymentValue(request.PaymentValue)
                .SetPaymentOrderId(request.OrderId)
                .SetPaymentProductId(request.ProductId)
                .Build();
            
            _repository.CreatePayment(payment);
            return Task.FromResult(true);
        }
        catch
        {
            return Task.FromResult(false);
        }

    }
}