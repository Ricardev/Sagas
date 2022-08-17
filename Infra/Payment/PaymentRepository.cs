using Domain.Payment;
using Infra.Payment.Context;

namespace Infra.Payment;

public class PaymentRepository : IPaymentRepository
{
    private readonly PaymentContext _context;

    public PaymentRepository(PaymentContext context)
    {
        _context = context;
    }
    public Domain.Payment.Payment CreatePayment(Domain.Payment.Payment payment)
    {
        return _context.Add(payment).Entity;
    }
}