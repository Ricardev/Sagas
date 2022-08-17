using MediatR;

namespace Domain.Payment.Command;

public class CreatePaymentCommand : IRequest<bool>
{
    public int PaymentValue { get; }
    public int OrderId { get; }
}