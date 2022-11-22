using MediatR;

namespace Domain.Payment.Command;

public class CreatePaymentCommand : IRequest<bool>
{
    public int PaymentValue { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
}