using MediatR;

namespace Domain.Payment.Command;

public class CreatePaymentCommand : IRequest
{
    public int PaymentValue { get; }
    public int OrderId { get; }
}